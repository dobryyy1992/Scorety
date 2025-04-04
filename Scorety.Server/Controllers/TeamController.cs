using Microsoft.AspNetCore.Mvc;
using Scorety.Server.DTOs;
using Scorety.Server.Services.Interfaces;

namespace Scorety.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamController : ControllerBase
    {
        private readonly ILogger<TeamController> _logger;
        private readonly ITeamService _teamService;

        public TeamController(ILogger<TeamController> logger, ITeamService teamService)
        {
            _logger = logger;
            _teamService = teamService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<TeamDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<TeamDto>>> GetAllTeams()
        {
            try
            {
                var teams = await _teamService.GetAllTeamsAsync();
                return Ok(teams.ToList());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving teams");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(TeamDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TeamDto>> GetById(Guid id)
        {
            try
            {
                var team = await _teamService.GetTeamByIdAsync(id);

                if (team == null)
                    return NotFound($"Team with ID {id} not found.");

                return Ok(team);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error retrieving team with id {id}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
