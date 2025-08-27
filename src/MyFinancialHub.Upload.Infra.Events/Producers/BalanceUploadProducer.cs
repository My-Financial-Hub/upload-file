using MyFinancialHub.Infra.Events.Producers;
using MyFinancialHub.Upload.Domain.Events;

namespace MyFinancialHub.Upload.Infra.Events.Producers
{
    internal class UploadBalanceFileProducer(
        QueueClient queueClient,
        ILogger<UploadBalanceFileProducer> logger
    ) : IProducer<UploadBalanceFileEvent>
    {
        private readonly QueueClient queueClient = queueClient;
        private readonly ILogger<UploadBalanceFileProducer> logger = logger;

        public async Task ProduceAsync(UploadBalanceFileEvent message)
        {
            this.logger.LogInformation("Producing message");
            await this.queueClient.SendMessageAsync(message.FileName);
            this.logger.LogInformation("Message produced");
        }
    }
}
