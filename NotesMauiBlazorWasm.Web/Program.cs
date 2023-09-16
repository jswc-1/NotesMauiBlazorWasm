using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using NotesMauiBlazorWasm.Common.Interfaces;
using NotesMauiBlazorWasm.Common.Services;
using NotesMauiBlazorWasm.Web;
using NotesMauiBlazorWasm.Web.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddTransient<AuthServices>();
builder.Services.AddSingleton<IAlertService, AlertService>();
builder.Services.AddSingleton<IStorageService, StorageService>();

await builder.Build().RunAsync();
