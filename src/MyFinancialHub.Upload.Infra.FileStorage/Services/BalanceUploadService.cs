using MyFinancialHub.Upload.Domain.Interfaces.Services;

namespace MyFinancialHub.Upload.Infra.FileStorage.Services
{
    public class BalanceUploadService(
        BlobContainerClient containerClient,
        ILogger<BalanceUploadService> logger
    ) : IBalanceService
    {
        private readonly BlobContainerClient containerClient = containerClient;
        private readonly ILogger<BalanceUploadService> logger = logger;

        public async Task UploadFileAsync(string fileName, Stream fileStream)
        {
            this.logger.LogInformation("Uploading file {FileName} to blob storage", fileName);
            var blobClient = containerClient.GetBlobClient(fileName);
            this.logger.LogInformation("Uploading file {FileName} to blob storage at {Uri}", fileName, blobClient.Uri);

            this.logger.LogInformation("Starting upload of file {FileName}", fileName);
            await blobClient.UploadAsync(fileStream, true);
            this.logger.LogInformation("File {FileName} uploaded successfully", fileName);
        }
    }
}
