using Microsoft.AspNetCore.Mvc;
using VCA.Models;
using VCA.Repositories;

namespace VCA.Controllers
{
    [ApiController]
    [Route("api/components")]
    public class ComponentController : ControllerBase
    {
        private readonly IComponentRepository _componentRepository;

        public ComponentController(IComponentRepository componentRepository)
        {
            _componentRepository = componentRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllComponents()
        {
            try
            {
                var components = await _componentRepository.GetAllComponentsAsync();
                return Ok(components);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetComponentById(int id)
        {
            try
            {
                var component = await _componentRepository.GetComponentByIdAsync(id);
                if (component == null)
                    return NotFound();

                return Ok(component);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateComponent([FromBody] Component component)
        {
            try
            {
                if (component == null)
                    return BadRequest("Component object is null");

                var createdComponent = await _componentRepository.CreateComponentAsync(component);
                return CreatedAtAction(nameof(GetComponentById), new { id = createdComponent.Id }, createdComponent);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateComponent(int id, [FromBody] Component component)
        {
            try
            {
                if (component == null)
                    return BadRequest("Component object is null");

                var updatedComponent = await _componentRepository.UpdateComponentAsync(id, component);
                if (updatedComponent == null)
                    return NotFound();

                return Ok(updatedComponent);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComponent(int id)
        {
            try
            {
                await _componentRepository.DeleteComponentAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}

