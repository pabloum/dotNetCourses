// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
//
// Generated with Bot Builder V4 SDK Template for Visual Studio CoreBot v4.3.0

using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;

namespace BotWithLuis.Dialogs
{
    public class CakeOrderDialog : CancelAndHelpDialog
    {
        public CakeOrderDialog()
            : base(nameof(CakeOrderDialog))
        {
            AddDialog(new TextPrompt(nameof(TextPrompt)));
            AddDialog(new NumberPrompt<int>(nameof(NumberPrompt<int>)));
            AddDialog(new ConfirmPrompt(nameof(ConfirmPrompt)));
            AddDialog(new DateResolverDialog());
            AddDialog(new WaterfallDialog(nameof(WaterfallDialog), new WaterfallStep[]
            {
                CakeTypeStepAsync,
                QuantityStepAsync,
                DeliveryDateStepAsync,
                ConfirmStepAsync,
                FinalStepAsync,
            }));

            // The initial child Dialog to run.
            InitialDialogId = nameof(WaterfallDialog);
        }

        private async Task<DialogTurnResult> CakeTypeStepAsync(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            var cakeOrder = (CakeOrder)stepContext.Options;

            return string.IsNullOrEmpty(cakeOrder.CakeName) 
                ?
                await stepContext.PromptAsync(nameof(TextPrompt), 
                    new PromptOptions {
                        Prompt = MessageFactory.Text("What cake would you like to order?")
                    }, 
                    cancellationToken)
                :
                await stepContext.NextAsync(cakeOrder.CakeName, cancellationToken);
        }

        private async Task<DialogTurnResult> QuantityStepAsync(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            var cakeOrder = (CakeOrder)stepContext.Options;
            cakeOrder.CakeName = !string.IsNullOrEmpty(cakeOrder.CakeName) 
                ? 
                cakeOrder.CakeName 
                : 
                (string)stepContext.Result;

            return string.IsNullOrEmpty(cakeOrder.Quantity)
                ?
                await stepContext.PromptAsync(nameof(TextPrompt),
                    new PromptOptions
                    {
                        Prompt = MessageFactory.Text("How many items?")
                    },
                    cancellationToken)
                :
                await stepContext.NextAsync(cakeOrder.Quantity, cancellationToken);
        }

        private async Task<DialogTurnResult> DeliveryDateStepAsync(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            var cakeOrder = (CakeOrder)stepContext.Options;
            cakeOrder.Quantity = !string.IsNullOrEmpty(cakeOrder.Quantity)
                ?
                cakeOrder.Quantity
                :
                (string)stepContext.Result;

            return (string.IsNullOrEmpty(cakeOrder.Delivery))
                ?
                await stepContext.BeginDialogAsync(nameof(DateResolverDialog), cakeOrder.Delivery, cancellationToken)
                :
                await stepContext.NextAsync(cakeOrder.Delivery, cancellationToken);
        }

        private async Task<DialogTurnResult> ConfirmStepAsync(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            var cakeOrder = (CakeOrder)stepContext.Options;
            cakeOrder.Delivery = !string.IsNullOrEmpty(cakeOrder.Delivery)
                ?
                cakeOrder.Delivery
                :
                (string)stepContext.Result;

            var msg = $"Please confirm your order: {Environment.NewLine}" +
                $"{cakeOrder?.Quantity} {cakeOrder?.CakeName} {Environment.NewLine}" +
                $"for {cakeOrder?.Delivery} {Environment.NewLine}";

            return await stepContext.PromptAsync(nameof(ConfirmPrompt), 
                new PromptOptions
                {
                    Prompt = MessageFactory.Text(msg)
                }, 
                cancellationToken);
        }

        private async Task<DialogTurnResult> FinalStepAsync(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            if ((bool)stepContext.Result)
            {
                var cakeOrder = (CakeOrder)stepContext.Options;
                return await stepContext.EndDialogAsync(cakeOrder, cancellationToken);
            }
            else
            {
                return await stepContext.EndDialogAsync(null, cancellationToken);
            }
        }
    }
}
