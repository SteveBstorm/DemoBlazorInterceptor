using DemoBlazorInterceptor.Client;
using DemoBlazorInterceptor.Client.Infrastructure;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;



var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
//ajouter le nuget Microsoft.Extensions.Http
builder.Services.AddTransient<TokenInterceptor>();
builder.Services.AddTransient<HttpErrorHandler>();
builder.Services.AddHttpClient("apiServer", sp =>
    {
        new HttpClient();
        sp.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
    })
    //.AddHttpMessageHandler<TokenInterceptor>()
    .AddHttpMessageHandler<HttpErrorHandler>();
await builder.Build().RunAsync();
