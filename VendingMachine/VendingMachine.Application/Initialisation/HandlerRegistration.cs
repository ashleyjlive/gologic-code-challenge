using Microsoft.Extensions.DependencyInjection;

namespace VendingMachine.Application.Initialisation
{
    public static class HandlerRegistration
    {
        public static IServiceCollection RegisterApplicationHandlers(this IServiceCollection services)
        {
            return services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssembly(System.Reflection.Assembly.GetExecutingAssembly());
            });
        }
    }
}
