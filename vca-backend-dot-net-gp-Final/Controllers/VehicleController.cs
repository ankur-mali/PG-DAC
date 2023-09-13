using Microsoft.AspNetCore.Mvc;
using VCA.Services.Vehical;

namespace VCA.Controllers
{
    [ApiController]
    [Route("api")]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleRepository _vehicleService;

        public VehicleController(IVehicleRepository vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [HttpGet("vehicles/{comp_type}/{id}")]
        public async Task<IActionResult> GetVehicleByID(char comp_type, int id)
        {
            try
            {
                var data = await _vehicleService.FindCompByModelIdAsync(id, comp_type);
                return Ok(new { message = "Vehicle data", status = "success", data });
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message, status = "error", data = (object)null });
            }
        }
    }
}

