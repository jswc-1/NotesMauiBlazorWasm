using Microsoft.JSInterop;
using NotesMauiBlazorWasm.Common;
using NotesMauiBlazorWasm.Common.Interfaces;

namespace NotesMauiBlazorWasm.Web.Services
{
    public class AlertService: IAlertService
    {

        public readonly IJSRuntime _jSRuntime;

        public AlertService(IJSRuntime jSRuntime)
        {
            _jSRuntime = jSRuntime;
        }
        public async Task AlertAsync(string message, string title = "Alert", string buttonName = "OK")
        {
            await _jSRuntime.InvokeVoidAsync("window.alert", $"{title}\n{message}");
        }

        public async Task<string?> PromptAsync(string message, string title)
        {
            return await _jSRuntime.InvokeAsync<string?>("window.prompt", $"{title}\n{message}");
        }
    }
}
