using Microsoft.AspNetCore.Mvc;
using MyFinancialHub.Upload.Application.Handlers.UploadPdfFile;

namespace MyFinancialHub.Upload.WebApi.Controllers
{
    [ApiController]
    [Route("api/upload-balances")]
    public class UploadBalanceController(IDispatcher dispatcher) : ControllerBase
    {
        private readonly IDispatcher dispatcher = dispatcher;

        [HttpPost("pdf/{accountName}")]
        public async Task<IActionResult> Post(
            [FromRoute] string accountName,
            [FromForm] IFormFile file
            )
        {
            if(file.Headers.ContentType != "application/pdf")
                return BadRequest("Only PDF files are allowed.");
            if(file.Length > 500 * 1024 * 1024)
                return BadRequest("File size exceeds the 500MB limit.");

            var command = new UploadPdfFileCommand(
                file.OpenReadStream(), 
                accountName
            );
            await this.dispatcher.Dispatch(command);
            return Created();
        }
    }
}
