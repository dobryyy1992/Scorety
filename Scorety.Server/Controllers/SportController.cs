using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Scorety.Server.DTOs;
using Scorety.Server.Models;
using Scorety.Server.Services.Interfaces;
namespace Scorety.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SportController : ControllerBase
    {
        private readonly ILogger<SportController> _logger;
        private readonly ISportService _sportService;

        public SportController(ILogger<SportController> logger, ISportService sportService)
        {
            _logger = logger;
            _sportService = sportService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<SportDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<SportDto>>> GetAllSports()
        {
            try
            {
                var sports = await _sportService.GetAllSportsAsync();
                return Ok(sports.ToList());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving sports");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(SportDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<SportDto>> GetById(Guid id)
        {
            try
            {
                var sport = await _sportService.GetSportByIdAsync(id);

                if (sport == null)
                    return NotFound($"Sport with ID {id} not found.");

                return Ok(sport);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error retrieving sport with id {id}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(CreateSportDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CreateSportDto>> CreateSport([FromBody] CreateSportDto sportDto)
        {
            if (sportDto == null)
                return BadRequest("Sport data cannot be null");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var createdSport = await _sportService.CreateSportAsync(sportDto);

                return CreatedAtAction(nameof(GetById), new { id = createdSport.Id }, createdSport);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating sport");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(UpdateSportDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UpdateSportDto>> UpdateSport(Guid id, [FromBody] UpdateSportDto sportDto)
        {
            if (id == Guid.Empty || !ModelState.IsValid)
                return BadRequest();

            try
            {
                var updatedSport = await _sportService.UpdateSportAsync(id, sportDto);

                if (updatedSport == null)
                    return NotFound($"Sport with ID {id} not found.");

                return Ok(updatedSport);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error updating sport with id {id}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPatch("{id}")]
        [ProducesResponseType(typeof(UpdateSportDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UpdateSportDto>> PatchSport(Guid id, [FromBody] JsonPatchDocument<UpdateSportDto> patchDocument)
        {
            if (id == Guid.Empty || patchDocument == null)
                return BadRequest();

            try
            {
                var result = await _sportService.PatchSportAsync(id, patchDocument);

                if(!result.Success)
                    return NotFound(result.Message);

                return Ok(result.Data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error updating sport with id {id}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteSport(Guid id)
        {
            if (id == Guid.Empty)
                return BadRequest();

            try
            {
                var deleted = await _sportService.DeleteSportAsync(id);

                if (!deleted)
                    return NotFound($"Sport with ID {id} not found.");

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error deleting sport with id {id}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
