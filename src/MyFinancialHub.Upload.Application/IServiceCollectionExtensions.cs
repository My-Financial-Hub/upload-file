using MyFinancialHub.Application.CQRS.Handlers.Commands;
using MyFinancialHub.Upload.Application.Handlers.UploadPdfFile;

namespace MyFinancialHub.Upload.Application
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddUploadApplication(this IServiceCollection services)
        {
            services.AddScoped<ICommandHandler<UploadPdfFileCommand>, UploadPdfFileCommandHandler>();
            return services;
        }
    }
}
