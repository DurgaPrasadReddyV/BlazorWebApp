using System.Reflection;
using WebAppStarter.Infrastructure;
using WebAppStarter.UseCases.TodoItems;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static void AddInfrastructureServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<ITodoItemRepository,TodoItemRepository>();
    }
}
