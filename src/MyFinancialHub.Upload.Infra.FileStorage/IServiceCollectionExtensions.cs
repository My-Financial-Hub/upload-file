using MyFinancialHub.Upload.Infra.FileStorage.Configurations;
using MyFinancialHub.Upload.Infra.FileStorage.Services;

namespace MyFinancialHub.Upload.Infra.FileStorage
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddUploadFileStorage(this IServiceCollection services)
        {
            return services
                .AddQueueStorageConfigurations()
                .AddBlobStorageServices();
        }
    }
}
