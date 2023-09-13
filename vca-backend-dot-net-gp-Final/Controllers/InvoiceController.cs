using Microsoft.AspNetCore.Mvc;
using VCA.Services.Invoices;

namespace VCA.Controllers
{
    [ApiController]
    [Route("api")]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceRepository _invoiceService;

        public InvoiceController(IInvoiceRepository invoiceService)
        {
            _invoiceService = invoiceService;
        }

        [HttpGet("Invoice/{id}")]
        public async Task<IActionResult> GetInvoiceByID(int id)
        {
            try
            {
                var data = await _invoiceService.FindInvoiceByInvoiceIdAsync(id);
                return Ok(new { message = "Vehicle data", status = "success", data });
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message, status = "error", data = (object)null });
            }
        }
    }
}
