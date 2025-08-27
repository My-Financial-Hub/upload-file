using Microsoft.Extensions.Options;
using MyFinancialHub.Upload.Domain.Interfaces.Services;
using MyFinancialHub.Upload.Infra.FileStorage.Configurations;

namespace MyFinancialHub.Upload.Infra.FileStorage.Services
{
    internal static class IServiceCollectionExtensions
    {
        internal static IServiceCollection AddBlobStorageServices(this IServiceCollection services)
        {
            services.AddScoped<IBalanceService>(service =>
            {
                var configuration = service.GetRequiredService<IOptions<BlobStorageConfigurations>>();
                var blobServiceClient = new BlobServiceClient(configuration.Value.ConnectionString);
                return new BalanceUploadService(
                    blobServiceClient.GetBlobContainerClient(configuration.Value.ContainerName),
                    service.GetRequiredService<ILogger<BalanceUploadService>>()
                );
            });
            return services;
        }
    }
}
