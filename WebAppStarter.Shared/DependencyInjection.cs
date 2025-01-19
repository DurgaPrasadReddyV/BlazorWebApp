using Blazored.LocalStorage;
using MudBlazor;
using MudBlazor.Services;
using System.Reflection;
using WebAppStarter.Shared.UI.Services;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static void AddSharedServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddMudServices(config =>
        {
            MudGlobal.InputDefaults.ShrinkLabel = true;
            config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomCenter;
            config.SnackbarConfiguration.NewestOnTop = false;
            config.SnackbarConfiguration.ShowCloseIcon = true;
            config.SnackbarConfiguration.VisibleStateDuration = 3000;
            config.SnackbarConfiguration.HideTransitionDuration = 500;
            config.SnackbarConfiguration.ShowTransitionDuration = 500;
            config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
        });

        serviceCollection.AddBlazoredLocalStorage();
        serviceCollection.AddScoped<IStorageService, LocalStorageService>();
        serviceCollection.AddScoped<IUserPreferencesService, UserPreferencesService>();
        serviceCollection.AddScoped<LayoutService>();
        serviceCollection.AddScoped<WebAppStarter.Shared.UI.Services.DialogService>();
        serviceCollection.AddScoped<OfflineModeState>();
    }
}
