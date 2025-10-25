using Microsoft.AspNetCore.Mvc;
using Scorety.Server.Services.Interfaces;

namespace Scorety.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LeagueController : ControllerBase
    {
        private readonly ILogger<LeagueController> _logger;
        private readonly ILeagueService _leagueService;

        public LeagueController(ILogger<LeagueController> logger, ILeagueService leagueService)
        {
            _logger = logger;
            _leagueService = leagueService;
        }
    }
}
