using Microsoft.Extensions.Options;
using MyFinancialHub.Upload.Infra.Events.Configurations;

namespace MyFinancialHub.Upload.Infra.Events.Producers;

internal static class IServiceCollectionExtensions
{
    public static IServiceCollection AddUploadEventProducers(this IServiceCollection services)
    {
        services.AddScoped(service =>
        {
            var configuration = service.GetRequiredService<IOptions<QueueStorageConfigurations>>();
            return new UploadBalanceFileProducer(
                new QueueClient(
                    configuration.Value.ConnectionString, 
                    configuration.Value.QueueName
                ),
                service.GetRequiredService<ILogger<UploadBalanceFileProducer>>()
            );
        });

        return services;
    }
}
