namespace MyFinancialHub.Upload.Infra.FileStorage.Configurations
{
    internal class BlobStorageConfigurations
    {
        public string ConnectionString { get; init; } = string.Empty;
        public string ContainerName { get; init; } = string.Empty;
    }
}
