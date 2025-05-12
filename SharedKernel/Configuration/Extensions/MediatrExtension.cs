using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace SharedKernel.Configuration.Extensions
{
    public static class MediatrExtension
    {
        public static void AddmediatRApi(this IServiceCollection services, Assembly assembly)
        {
            services.AddMediatR(option =>
            {
                option.RegisterServicesFromAssembly(assembly);
            });
        }
    }
}
