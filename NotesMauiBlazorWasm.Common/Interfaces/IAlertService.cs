namespace NotesMauiBlazorWasm.Common.Interfaces
{
    public interface IAlertService
    {
        Task<string?> PromptAsync(string message, string title);
        Task AlertAsync(string message, string title = "Alert", string buttonName= "OK");
    }
}
