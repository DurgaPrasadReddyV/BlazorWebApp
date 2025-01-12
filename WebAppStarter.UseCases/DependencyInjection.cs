using System.Reflection;
using FluentValidation;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static void AddUseCasesServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddAutoMapper(Assembly.GetExecutingAssembly());

        serviceCollection.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        serviceCollection.AddMediatR(cfg => 
        { 
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()); 
        });
    }
}
