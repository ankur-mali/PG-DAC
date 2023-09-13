using Microsoft.AspNetCore.Mvc;
using VCA.Services.Segments;
namespace VCA.Controllers
{
    [ApiController]
    [Route("api")]
    public class SegmentController : ControllerBase
    {
        private readonly ISegmentService _segmentService;

        public SegmentController(ISegmentService segmentService)
        {
            _segmentService = segmentService;
        }

        [HttpGet("segments")]
        public IActionResult GetAllSegments()
        {
            try
            {
                var data = _segmentService.GetAllSegments();
                return Ok(new
                {
                    message = "Segments retrieved successfully",
                    data
                });
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


