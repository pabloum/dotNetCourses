// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
//
// Generated with Bot Builder V4 SDK Template for Visual Studio CoreBot v4.3.0

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.AI.Luis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Recognizers.Text;
using Microsoft.Recognizers.Text.DateTime;

namespace BotWithLuis
{
    public static class LuisHelper
    {
        public static async Task<CakeOrder> ExecuteLuisQuery(IConfiguration configuration, ILogger logger, 
            ITurnContext turnContext, 
            CancellationToken cancellationToken)
        {
            var cakeOrder = new CakeOrder();

            try
            {
                // Create the LUIS settings from configuration.
                var luisApplication = new LuisApplication(
                    configuration["LuisAppId"],
                    configuration["LuisAPIKey"],
                    configuration["LuisAPIHostName"]
                );

                var recognizer = new LuisRecognizer(luisApplication);

                // The actual call to LUIS
                try
                {
                    var recognizerResult = await recognizer.RecognizeAsync(turnContext, cancellationToken);
                    if (recognizerResult != null)
                    {
                        var (intent, score) = recognizerResult.GetTopScoringIntent();

                        if (intent == "CakeOrder")
                        {
                            GetCakeName(ref cakeOrder, recognizerResult);
                            GetQuantity(ref cakeOrder, recognizerResult);
                            GetDelivery(ref cakeOrder, recognizerResult);
                        }
                    }
                }
                catch (Exception e)
                {
                    logger.LogWarning($"LUIS Exception: {e.Message}.");
                }
            }
            catch (Exception e)
            {
                logger.LogWarning($"LUIS Exception: {e.Message} Check your LUIS configuration.");
            }

            return cakeOrder;
        }

        private static void GetCakeName(ref CakeOrder cakeOrder, RecognizerResult recognizerResult)
        {
            string n = recognizerResult.Entities["FullCake"]?.FirstOrDefault().ToString();
            cakeOrder.CakeName = !string.IsNullOrEmpty(n) ? n : string.Empty;

            if (string.IsNullOrEmpty(cakeOrder.CakeName))
            {
                n = recognizerResult.Entities["SmallCake"]?.FirstOrDefault().ToString();
                cakeOrder.CakeName = !string.IsNullOrEmpty(n) ? n : string.Empty;
            }
        }

        private static void GetQuantity(ref CakeOrder cakeOrder, RecognizerResult recognizerResult)
        {
            string n = recognizerResult.Entities["number"]?.FirstOrDefault().ToString();
            cakeOrder.Quantity = !string.IsNullOrEmpty(n) ? n : string.Empty;
        }

        private static void GetDelivery(ref CakeOrder cakeOrder, RecognizerResult recognizerResult)
        {
            string d = recognizerResult.Entities["$instance"]?["datetime"]?.First()?["text"].ToString();

            ValidateDate(d, out string date, out string _);

            cakeOrder.Delivery = !string.IsNullOrEmpty(date) ? date : string.Empty;
        }

        public static bool ValidateDate(string input, out string date, out string message)
        {
            date = null;
            message = null;

            try
            {
                var results = DateTimeRecognizer.RecognizeDateTime(input, Culture.English);
                var earliest = DateTime.Now.AddHours(1.0);

                foreach (var result in results)
                {
                    var resolutions = result.Resolution["values"] as List<Dictionary<string, string>>;

                    foreach (var resolution in resolutions)
                    {
                        if (resolution.TryGetValue("value", out string dateString)
                            || resolution.TryGetValue("start", out dateString))
                        {
                            if (DateTime.TryParse(dateString, out DateTime candidate)
                                && earliest < candidate)
                            {
                                date = candidate.ToShortDateString();
                                return true;
                            }
                        }
                    }
                }

                message = "I'm sorry, please enter a date at least an hour from now.";
            }
            catch
            {
                message = "I'm sorry, I could not interpret that as an correct date. Please enter a date at least an hour from now.";
            }

            return false;
        }
    }
}
