using Microsoft.AspNetCore.Mvc;
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
        [Route("GetAll")]
        [ProducesResponseType(typeof(List<Sport>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<Sport>>> GetAllSports()
        {
            try
            {
                var sports = await _sportService.GetAllSportsAsync();
                return Ok(sports);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving sports");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet]
        [Route("GetById/{id}")]
        [ProducesResponseType(typeof(Sport), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Sport>> GetSportById(Guid id)
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
                _logger.LogError(ex, "Error retrieving sport with id {Id}", id);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet]
        [Route("GetByName/{name}")]
        [ProducesResponseType(typeof(Sport), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Sport>> GetSportByName(string name)
        {
            try
            {
                var sport = await _sportService.GetSportByNameAsync(name);
                if (sport == null)
                    return NotFound();

                return Ok(sport);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving sport with name {Name}", name);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        [Route("Create")]
        [ProducesResponseType(typeof(Sport), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Sport>> CreateSport([FromBody] Sport sport)
        {
            try
            {
                var createdSport = await _sportService.CreateSportAsync(sport);
                return CreatedAtAction(nameof(GetSportById), new { id = createdSport.Id }, createdSport);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating sport");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut]
        [Route("Update")]
        [ProducesResponseType(typeof(Sport), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Sport>> UpdateSport([FromBody] Sport sport)
        {
            try
            {
                if (sport.Id == Guid.Empty)
                    return BadRequest();

                await _sportService.UpdateSportAsync(sport);
                return Ok(sport);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating sport with id {Id}", sport.Id);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteSport(Guid id)
        {
            try
            {
                await _sportService.DeleteSportAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting sport with id {Id}", id);
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
