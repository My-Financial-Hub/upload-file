using Microsoft.Extensions.Configuration;

namespace MyFinancialHub.Upload.Infra.FileStorage.Configurations
{
    internal static class IServiceCollectionExtensions
    {
        internal static IServiceCollection AddQueueStorageConfigurations(this IServiceCollection services)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile("appsettings.development.json", optional: true, reloadOnChange: false)
                .Build();

            services.Configure<BlobStorageConfigurations>(
                configuration.GetSection("Azure:BlobStorage")
            );

            return services;
        }
    }
}
