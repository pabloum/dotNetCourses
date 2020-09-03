// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
//
// Generated with Bot Builder V4 SDK Template for Visual Studio EchoBot v4.3.0

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;
using Microsoft.Recognizers.Text;
using Microsoft.Recognizers.Text.DateTime;
using Microsoft.Recognizers.Text.Number;

namespace BotNoLuis.Bots
{
    public class CakeOrder
    {
        public int Step { get; set; }
        public string CakeType { get; set; }
        public string CakeName { get; set; }
        public int Quantity { get; set; }
        public string Delivery { get; set; }
    }

    public class EchoBot : ActivityHandler
    {
        private BotState _conversationState;
        private CakeOrder conversationData = null;

        public EchoBot(ConversationState conversationState)
        {
            _conversationState = conversationState;
        }

        private async Task<CakeOrder> GetState(ITurnContext turnContext)
        {
            var conversationStateAccessors = _conversationState.CreateProperty<CakeOrder>(nameof(CakeOrder));
            var data = await conversationStateAccessors.GetAsync(turnContext, () => new CakeOrder());
            return data;
        }

        // Saves the current state
        public override async Task OnTurnAsync(ITurnContext turnContext, CancellationToken cancellationToken = default)
        {
            await base.OnTurnAsync(turnContext, cancellationToken);
            await _conversationState.SaveChangesAsync(turnContext, false, cancellationToken);
        }

        protected override async Task OnMessageActivityAsync(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
        {
            string txt = turnContext.Activity.Text.ToLowerInvariant();

            await turnContext.SendActivityAsync(MessageFactory.Text($"Bot confirms: {txt}"), cancellationToken);
            await ProcessOrder(turnContext, cancellationToken, txt);
        }

        private async Task ProcessOrder(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken, string txt)
        {
            // Retrieves the current State
            conversationData = await GetState(turnContext);

            switch (conversationData.Step)
            {
                case 0:
                    conversationData.CakeType = txt;
                    conversationData.Step = 1;
                    if (conversationData.CakeType.ToLower().Contains("full"))
                        await FullCakeAsync(turnContext, cancellationToken);
                    else
                        await SmallCakeAsync(turnContext, cancellationToken);
                    break;

                case 1:
                    conversationData.CakeName = txt;
                    conversationData.Step = 2;
                    await QuantityAsync(turnContext, cancellationToken);
                    break;

                case 2:
                    string message;
                    if (ValidateNumber(txt, out int q, out message))
                    {
                        conversationData.Quantity = q;
                        conversationData.Step = 3;
                        await DeliveryDateAsync(turnContext, cancellationToken);
                        break;
                    }
                    else
                    {
                        await turnContext.SendActivityAsync(message ?? "... I'm sorry, I didn't understand that.");
                        break;
                    }

                case 3:
                    string msg;
                    if (ValidateDate(txt, out string date, out msg))
                    {
                        conversationData.Delivery = date;

                        await turnContext.SendActivityAsync($"Your order: " +
                            $"{conversationData.CakeType} {Environment.NewLine}" +
                            $"{conversationData.CakeName} {Environment.NewLine}" +
                            $"{conversationData.Quantity} {Environment.NewLine}" +
                            $"{conversationData.Delivery}");

                        CleanUpStateData();
                        break;
                    }
                    else
                    {
                        await turnContext.SendActivityAsync(msg ?? "... I'm sorry, I didn't understand that.");
                        break;
                    }

                default:
                    break;
            }
        }

        private void CleanUpStateData()
        {
            conversationData.CakeType = string.Empty;
            conversationData.CakeName = string.Empty;
            conversationData.Quantity = -1;
            conversationData.Delivery = string.Empty;
        }

        protected override async Task OnMembersAddedAsync(IList<ChannelAccount> membersAdded, ITurnContext<IConversationUpdateActivity> turnContext, CancellationToken cancellationToken)
        {
            foreach (var member in membersAdded)
            {
                if (member.Id != turnContext.Activity.Recipient.Id)
                {
                    // Retrieves the current State
                    conversationData = await GetState(turnContext);
                    conversationData.Step = 0;

                    await turnContext.SendActivityAsync(MessageFactory.Text($"Hello and Welcome to the Cake Bot (without LUIS)"), cancellationToken);
                    await FullOrSmallAsync(turnContext, cancellationToken);
                }
            }
        }

        private static async Task FullOrSmallAsync(ITurnContext turnContext, CancellationToken cancellationToken)
        {
            string qry = "Would you like to order a full cake or a small cake?";

            SuggestedActions sa = new SuggestedActions()
            {
                Actions = new List<CardAction>()
                {
                    new CardAction() { Title = "FullCake", Type = ActionTypes.ImBack, Value = "Full cake" },
                    new CardAction() { Title = "SmallCake", Type = ActionTypes.ImBack, Value = "Small cake" }
                },
            };

            await SendSuggestedActionAsync(qry, sa, turnContext, cancellationToken);
        }

        private static async Task FullCakeAsync(ITurnContext turnContext, CancellationToken cancellationToken)
        {
            string qry = "Which full cake would you like?";

            SuggestedActions sa = new SuggestedActions()
            {
                Actions = new List<CardAction>()
                {
                    new CardAction() { Title = "CreamCake", Type = ActionTypes.ImBack, Value = "Cream cake" },
                    new CardAction() { Title = "CheeseCake", Type = ActionTypes.ImBack, Value = "Cheese cake" },
                    new CardAction() { Title = "ChocolateCake", Type = ActionTypes.ImBack, Value = "Chocolate cake" }
                },
            };

            await SendSuggestedActionAsync(qry, sa, turnContext, cancellationToken);
        }

        private static async Task SmallCakeAsync(ITurnContext turnContext, CancellationToken cancellationToken)
        {
            string qry = "Which small cake would you like?";

            SuggestedActions sa = new SuggestedActions()
            {
                Actions = new List<CardAction>()
                {
                    new CardAction() { Title = "Brownie", Type = ActionTypes.ImBack, Value = "Brownie" },
                    new CardAction() { Title = "Cupcake", Type = ActionTypes.ImBack, Value = "Cupcake" }
                },
            };

            await SendSuggestedActionAsync(qry, sa, turnContext, cancellationToken);
        }

        private static bool ValidateNumber(string input, out int q, out string message)
        {
            q = 0;
            message = null;

            // Try to recognize the input as a number. This works for responses such as "twelve" as well as "12".
            try
            {
                var results = NumberRecognizer.RecognizeNumber(input, Culture.English);

                foreach (var result in results)
                {
                    // The result resolution is a dictionary, where the "value" entry contains the processed string.
                    if (result.Resolution.TryGetValue("value", out object value))
                    {
                        q = Convert.ToInt32(value);
                        if (q >= 1 && q <= 120)
                        {
                            return true;
                        }
                    }
                }

                message = "Please enter a number between 1 and 120.";
            }
            catch
            {
                message = "I'm sorry, I could not interpret that as a valid quantity. Please enter a number between 1 and 120.";
            }

            return message is null;
        }

        private static async Task QuantityAsync(ITurnContext turnContext, CancellationToken cancellationToken)
        {
            string qry = "How many would you like?";
            await SendSuggestedActionAsync(qry, null, turnContext, cancellationToken);
        }

        private static bool ValidateDate(string input, out string date, out string message)
        {
            date = null;
            message = null;

            // This works for responses such as "11/14/2018", "9pm", "tomorrow", "Sunday at 5pm", and so on.
            // The recognizer returns a list of potential recognition results, if any.
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

        private static async Task DeliveryDateAsync(ITurnContext turnContext, CancellationToken cancellationToken)
        {
            string qry = "When do you want it delivered?";
            await SendSuggestedActionAsync(qry, null, turnContext, cancellationToken);
        }

        private static async Task SendSuggestedActionAsync(string qry, SuggestedActions sa, ITurnContext turnContext, CancellationToken cancellationToken)
        {
            var reply = MessageFactory.Text(qry);
            reply.SuggestedActions = sa;

            await turnContext.SendActivityAsync(reply, cancellationToken);
        }
    }
}
