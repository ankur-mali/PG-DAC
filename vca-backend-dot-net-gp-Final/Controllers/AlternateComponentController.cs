using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using VCA.Services.AlternateComponent;

namespace VCA.Controllers
{
    [Route("api/alternate-components")]
    [ApiController]
    //[EnableCors("*")]
    public class AlternateComponentController : ControllerBase
    {
        private readonly IAlternateComponentRepository alternateComponentRepository;

        public AlternateComponentController(IAlternateComponentRepository service)
        {
            alternateComponentRepository = service;
        }

        [HttpGet("{modId}/{compId}")]
        public async Task<IActionResult> ShowAlternateComponents(int modId, int compId)
        {
            try
            {
                List<Dictionary<string, object>> data = await alternateComponentRepository.FindByModelIdAndCompIdAsync(modId, compId);
                return Ok(new
                {
                    status = "success",
                    message = "Alternate components retrieved successfully",
                    data = data
                });
            }
            catch (Exception e)
            {
                return BadRequest(new
                {
                    status = "error",
                    message = e.Message
                });
            }
        }
    }
}
