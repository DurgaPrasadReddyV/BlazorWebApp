using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System.IdentityModel.Tokens.Jwt;
using WebAppStarter.Authentication;
using WebAppStarter.Shared.UI.Pages;
using WebAppStarter.Components;
using Microsoft.AspNetCore.Components.Authorization;
using WebAppStarter.Client.Authentication;
using WebAppStarter.Services;
using WebAppStarter.Shared.Authentication;
using WebAppStarter.Shared.UseCases.TodoItems;

const string entraIdScheme = "EntraIDOpenIDConnect";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();
builder.Services.AddUseCasesServices();
builder.Services.AddSharedServices();
builder.Services.AddInfrastructureServices();

builder.Services.AddScoped<AuthenticationStateProvider, PersistingRevalidatingAuthenticationStateProvider>();
builder.Services.AddScoped<ITodoService, ServerTodoService>();
builder.Services.AddScoped<IScopedMediator, ScopedMediator>();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddOpenIdConnectAccessTokenManagement()
    .AddBlazorServerAccessTokenManagement<CustomServerSideTokenStore>();
builder.Services.AddTransient<CustomTokenStorageOidcEvents>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = entraIdScheme;
}).AddOpenIdConnect(entraIdScheme, oidcOptions =>
{
    oidcOptions.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    oidcOptions.Authority = "https://login.microsoftonline.com/a211a554-80be-47a0-805a-e5bb5eeeeddc/v2.0";
    oidcOptions.ResponseType = OpenIdConnectResponseType.Code;
    oidcOptions.UsePkce = true;
    oidcOptions.Scope.Add(OpenIdConnectScope.OpenIdProfile);
    oidcOptions.Scope.Add("offline_access");
    oidcOptions.CallbackPath = new PathString("/signin-oidc");
    oidcOptions.SignedOutCallbackPath = new PathString("/signout-callback-oidc");
    oidcOptions.MapInboundClaims = false;
    oidcOptions.TokenValidationParameters.NameClaimType = JwtRegisteredClaimNames.Name;
    oidcOptions.TokenValidationParameters.RoleClaimType = "role";
    oidcOptions.SaveTokens = true;
    oidcOptions.EventsType = typeof(CustomTokenStorageOidcEvents);

}).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
{
    options.AccessDeniedPath = new PathString("/AccessDenied");
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(AuthorizationPolicies.TodoItemDefault, AuthorizationPolicies.CanViewTodoItem());
    options.AddPolicy(AuthorizationPolicies.TodoItemCreate, AuthorizationPolicies.CanCreateTodoItem());
    options.AddPolicy(AuthorizationPolicies.TodoItemUpdate, AuthorizationPolicies.CanUpdateTodoItem());
    options.AddPolicy(AuthorizationPolicies.TodoItemDelete, AuthorizationPolicies.CanDeleteTodoItem());
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(WebAppStarter.Shared._Imports).Assembly);

app.MapGet("/login", (string? returnUrl, HttpContext httpContext) =>
{
    // ensure the returnUrl is valid & safe.  
    returnUrl = ValidateUri(httpContext, returnUrl);
    return TypedResults.Challenge(new AuthenticationProperties { RedirectUri = returnUrl });
}).AllowAnonymous();

app.MapPost("/logout", ([FromForm] string? returnUrl, HttpContext httpContext) =>
{
    returnUrl = ValidateUri(httpContext, returnUrl);
    return TypedResults.SignOut(new AuthenticationProperties { RedirectUri = returnUrl },
        [CookieAuthenticationDefaults.AuthenticationScheme, entraIdScheme]);
});

app.Run();

public partial class Program
{
    private static string ValidateUri(HttpContext httpContext, string? uri)
    {
        string basePath = string.IsNullOrEmpty(httpContext.Request.PathBase)
                ? "/" : httpContext.Request.PathBase;

        if (string.IsNullOrEmpty(uri))
        {
            return basePath;
        }
        else if (!Uri.IsWellFormedUriString(uri, UriKind.Relative))
        {
            return new Uri(uri, UriKind.Absolute).PathAndQuery;
        }
        else if (uri[0] != '/')
        {
            return $"{basePath}{uri}";
        }

        return uri;
    }
}
