using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WebAppStarter.Client.Authentication;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddSharedServices();

builder.Services.AddSingleton<AuthenticationStateProvider, PersistentAuthenticationStateProvider>();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();

builder.Services.AddHttpClient("ServerAPI",
      client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>()
  .CreateClient("ServerAPI"));

await builder.Build().RunAsync();
