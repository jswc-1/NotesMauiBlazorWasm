using NotesMauiBlazorWasm.Common.Interfaces;

namespace NotesMauiBlazorWasm.Services
{
    public class AlertService : IAlertService
    {
        public readonly Page _page;

        public AlertService()
        {
            _page = App.Current.MainPage; 
        }
        public async Task AlertAsync(string message, string title = "Alert", string buttonName = "OK")
        {
            await _page.DisplayAlert(title, message, buttonName);
        }

        public async Task<string> PromptAsync(string message, string title)
        {
            return await _page.DisplayPromptAsync(title, message, "OK"); 
        }
    }
}
