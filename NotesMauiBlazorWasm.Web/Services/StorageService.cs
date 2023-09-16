using Microsoft.JSInterop;
using NotesMauiBlazorWasm.Common.Interfaces;

namespace NotesMauiBlazorWasm.Web.Services
{
    public class StorageService : IStorageService
    {
        public readonly IJSRuntime _JSRuntime;
        public readonly string _storageName = "window.localStorage";

        public StorageService(IJSRuntime jSRuntime)
        {
            _JSRuntime = jSRuntime;
        }

        public async Task<string?> GetAsync(string key) =>
            await _JSRuntime.InvokeAsync<string>($"{_storageName}.getItem", key);

        public async Task SaveAsync(string key, string value) =>
            await _JSRuntime.InvokeVoidAsync($"{_storageName}.setItem", key, value);
    }
}
