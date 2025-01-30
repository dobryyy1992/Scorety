using Microsoft.AspNetCore.Mvc;
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

        [HttpGet] // GET api/sports
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

        [HttpGet("{id}")] // GET api/sports/{id}
        [ProducesResponseType(typeof(SportDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<SportDto>> GetById(Guid id)
        {
            try
            {
                var sport = await _sportService.GetSportByIdAsync(id);
                if (sport == null)
                    return NotFound();

                return Ok(sport);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error retrieving sport with id {id}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost] // POST api/sports
        [ProducesResponseType(typeof(CreateSportDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Sport>> CreateSport([FromBody] CreateSportDto sportDto)
        {
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

        [HttpPut("{id}")] // PUT api/sports/{id}
        [ProducesResponseType(typeof(Sport), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Sport>> UpdateSport(Guid id, [FromBody] UpdateSportDto sportDto)
        {
            try
            {
                if (id == Guid.Empty)
                    return BadRequest();

                var existingSport = await _sportService.GetSportByIdAsync(id);
                if (existingSport == null)
                    return NotFound($"Sport with ID {id} not found.");

                var updatedSport = await _sportService.UpdateSportAsync(id, sportDto);
                return Ok(updatedSport);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error updating sport with id {id}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")] // DELETE api/sports/{id}
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteSport(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                    return BadRequest();

                await _sportService.DeleteSportAsync(id);
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
