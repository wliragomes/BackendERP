using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.Configuration.Cache;
using SharedKernel.SharedObjects;

namespace SharedKernel.Configuration.Extensions
{
    public static class AddCacheExtension
    {
        public static void AddCacheProviderExtension(this IServiceCollection services, IConfigurationSection connectionStringSection)
        {
            services.AddSingleton<ICacheSettings, CacheSettings>(provider =>
            {
                var connectionString = connectionStringSection["route"];
                if (connectionString is null || connectionString.IsNullOrEmptyOrWhiteSpace())
                    throw new DomainException("É necessário cadastrar a connection string no appsettings do projeto.");

                return new CacheSettings(connectionString);
            });
            services.AddSingleton<ICacheProvider, CacheProvider>();
        }
    }
}
