namespace MyFinancialHub.Upload.Infra.Events.Configurations
{
    internal class QueueStorageConfigurations
    {
        public string ConnectionString { get; init; } = string.Empty;
        public string QueueName { get; init; } = string.Empty;
    }
}
