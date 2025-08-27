namespace MyFinancialHub.Upload.Domain.Interfaces.Services
{
    public interface IBalanceService
    {
        Task UploadFileAsync(string fileName, Stream fileStream);
    }
}
