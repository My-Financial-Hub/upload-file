using MyFinancialHub.Upload.Domain.Interfaces.Services;

namespace MyFinancialHub.Upload.Application.Handlers.UploadPdfFile
{
    internal class UploadPdfFileCommandHandler(
        IBalanceService fileService,
        ILogger<UploadPdfFileCommandHandler> logger
    ) : ICommandHandler<UploadPdfFileCommand>
    {
        private readonly IBalanceService fileService = fileService;
        private readonly ILogger<UploadPdfFileCommandHandler> logger = logger;

        public async Task Handle(UploadPdfFileCommand command)
        {
            this.logger.LogInformation("Uploading PDF file for account: {AccountName}", command.AccountName);
            await this.fileService.UploadFileAsync(
                $"{command.AccountName}.pdf", 
                command.PdfStream
            );
            this.logger.LogInformation("Successfully uploaded PDF file for account: {AccountName}", command.AccountName);
        }
    }
}
