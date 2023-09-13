using Microsoft.AspNetCore.Mvc;
using VCA.Services.Verient;

namespace VCA.Controllers
{
    [ApiController]
    [Route("api")]
    public class ModelController : ControllerBase
    {
        private readonly IModelRepository _modelRepository;

        public ModelController(IModelRepository modelRepository)
        {
            _modelRepository = modelRepository;
        }

        [HttpGet]
        [Route("models")]
        public async Task<IActionResult> GetAllModels([FromQuery] int page = 1)
        {
            var models = await _modelRepository.FindAllByOrderByCreatedAtDescAsync(page);

            Dictionary<string, Object> data = new Dictionary<string, Object>();
            data["data"] = new Dictionary<string, object>() { { "models", models } };

            return Ok(data);
        }

        [HttpGet]
        [Route("models/{segId}/{manuId}")]
        public async Task<IActionResult> GetModelsByManufacturerAndSegment(int segId, int manuId, [FromQuery] int page = 1)
        {
            var models = await _modelRepository.FindByManufacturerIdAndSegmentIdAsync(manuId, segId, page);
            return Ok(new Dictionary<string, object>() { { "data", new Dictionary<string, object>() { { "models", models } } } });
        }

        [HttpGet]
        [Route("models/{id}")]
        public async Task<IActionResult> GetModelById(int id)
        {
            var models = await _modelRepository.FindModelByIdAsync(id);

            if (models == null)
            {
                return NotFound(); // Return a 404 Not Found response if the model is not found
            }

            var data = new
            {
                data = new
                {
                    models
                }
            };

            return Ok(data);
        }
    }
}
