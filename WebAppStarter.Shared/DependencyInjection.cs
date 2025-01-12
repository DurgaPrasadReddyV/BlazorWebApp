using MudBlazor.Services;
using System.Reflection;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static void AddSharedServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddMudServices();
    }
}
