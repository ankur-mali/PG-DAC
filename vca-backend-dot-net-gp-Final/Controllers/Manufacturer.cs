using Microsoft.AspNetCore.Mvc;
using VCA.Models;
using VCA.Services.Manufaturers;
namespace V
    .Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ManufacturersController : ControllerBase
    {
        private readonly IManufacturerRepository _manufacturerService;

        public ManufacturersController(IManufacturerRepository manufacturerService)
        {
            _manufacturerService = manufacturerService;
        }

        [HttpGet("{segId}")]
        public async Task<IActionResult> GetManufacturers(int segId)
        {
            try
            {
                List<Manufacturer> data = await _manufacturerService.GetManufacturersBySegmentIdAsync(segId);
                return Ok(new { message = "Manufacturers retrieved successfully", data });
            }
            catch (Exception e)
            {
                return BadRequest(new
                {
                    message = e.Message,
                    data = (object)null
                } as object);
            }
        }
    }
}

