// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
//
// Generated with Bot Builder V4 SDK Template for Visual Studio CoreBot v4.3.0

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;

namespace BotWithLuis.Dialogs
{
    public class DateResolverDialog : CancelAndHelpDialog
    {
        public DateResolverDialog(string id = null)
            : base(id ?? nameof(DateResolverDialog))
        {
            AddDialog(new DateTimePrompt(nameof(DateTimePrompt), DateTimePromptValidator));
            AddDialog(new WaterfallDialog(nameof(WaterfallDialog), new WaterfallStep[]
            {
                InitialStepAsync,
                FinalStepAsync,
            }));

            // The initial child Dialog to run.
            InitialDialogId = nameof(WaterfallDialog);
        }

        private async Task<DialogTurnResult> InitialStepAsync(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            string delivery = (string)stepContext.Options;
            string promptMsg = "When would you like your order delivered?";

            if (string.IsNullOrEmpty(delivery))
            {
                // We were not given any date at all so prompt the user.
                return await stepContext.PromptAsync(nameof(DateTimePrompt),
                    new PromptOptions
                    {
                        Prompt = MessageFactory.Text(promptMsg),
                    }, cancellationToken);
            }

            return await stepContext.NextAsync(delivery, cancellationToken);
        }

        private static Task<bool> DateTimePromptValidator(PromptValidatorContext<IList<DateTimeResolution>>
            promptContext,
            CancellationToken cancellationToken)
        {
            if (promptContext.Recognized.Succeeded)
            {
                string d = (promptContext.Recognized.Value[0].Start == null)
                    ?
                    promptContext.Recognized.Value[0].Value.ToString()
                    :
                    promptContext.Recognized.Value[0].Start.ToString();

                return !string.IsNullOrEmpty(d) ? Task.FromResult(true) : Task.FromResult(false);
            }
            else
            {
                return Task.FromResult(false);
            }
        }

        private async Task<DialogTurnResult> FinalStepAsync(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            string delivery = DateTime.Parse(((List<DateTimeResolution>)
                stepContext.Result)?[0]?.Value).ToShortDateString() ?? string.Empty;
            return await stepContext.EndDialogAsync(delivery, cancellationToken);
        }
    }
}
