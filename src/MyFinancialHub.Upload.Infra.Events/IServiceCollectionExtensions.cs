using MyFinancialHub.Upload.Infra.Events.Configurations;
using MyFinancialHub.Upload.Infra.Events.Producers;

namespace MyFinancialHub.Upload.Infra.Events
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddUploadEvents(this IServiceCollection services)
        {
            return services
                .AddQueueStorageConfigurations()
                .AddUploadEventProducers();
        }
    }
}
