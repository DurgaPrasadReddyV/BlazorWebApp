using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppStarter.Shared.UI.Components;

namespace WebAppStarter.Shared.UI.Services
{
    public class DialogService
    {
        private readonly IDialogService _dialogService;

        public DialogService(IDialogService dialogService)
        {
            _dialogService = dialogService;
        }

        /// <summary>
        /// Shows a confirmation dialog with the specified title and content text.
        /// </summary>
        /// <param name="title">The title of the confirmation dialog.</param>
        /// <param name="contentText">The content text of the confirmation dialog.</param>
        /// <param name="onConfirm">The action to be executed when the confirmation is confirmed.</param>
        /// <param name="onCancel">The optional action to be executed when the confirmation is canceled.</param>
        public async Task ShowConfirmationDialog(string title, string contentText, Func<Task> onConfirm, Func<Task>? onCancel = null)
        {
            var parameters = new DialogParameters
        {
            { nameof(ConfirmationDialog.ContentText), contentText }
        };
            var options = new DialogOptions { CloseButton = true, MaxWidth = MaxWidth.ExtraSmall, FullWidth = true };
            var dialog = await _dialogService.ShowAsync<ConfirmationDialog>(title, parameters, options);
            var result = await dialog.Result;
            if (result is not null && !result.Canceled)
            {
                await onConfirm();
            }
            else if (onCancel != null)
            {
                await onCancel();
            }
        }

        public async Task ShowDialogAsync<T>(
            string title,
            DialogParameters<T> parameters,
            DialogOptions? options = null,
            Func<DialogResult, Task>? onConfirm = null,
            Func<Task>? onCancel = null) where T : ComponentBase
        {
            options = options ?? new DialogOptions { CloseButton = true, MaxWidth = MaxWidth.Medium, FullWidth = true };
            var dialog = await _dialogService.ShowAsync<T>(title, parameters, options);
            var result = await dialog.Result;
            if (result is not null && !result.Canceled && onConfirm is not null)
            {
                await onConfirm(result);
            }
            else if (result is not null && result.Canceled && onCancel is not null)
            {
                await onCancel();
            }
        }
    }
}
