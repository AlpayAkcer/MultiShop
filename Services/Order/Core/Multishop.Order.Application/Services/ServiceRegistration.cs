using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Multishop.Order.Application.Services
{
    public static class ServiceRegistration
    {
        public static void AddApplicationService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(typeof(ServiceRegistration).Assembly));


        }
    }
}
