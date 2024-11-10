using Microsoft.AspNetCore.Mvc;
using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Data.Models;
using PlanetaryExplorationLogs.API.Requests.Queries.Discoveries;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using PlanetaryExplorationLogs.API.Data.DTO;
using PlanetaryExplorationLogs.API.Requests.Commands.Discoveries.UpdateDiscoveryById;
using PlanetaryExplorationLogs.API.Requests.Queries.Discoveries.GetDiscoveryTypes;
using PlanetaryExplorationLogs.API.Requests.Commands.Discoveries.CreateDiscovery;
using PlanetaryExplorationLogs.API.Requests.Queries.Discoveries.GetDiscoveryById;
using PlanetaryExplorationLogs.API.Requests.Commands.Discoveries.DeleteDiscoveryById;
using PlanetaryExplorationLogs.API.Requests.Queries.Discoveries.GetDiscoveries;


namespace PlanetaryExplorationLogs.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscoveryController : ControllerBase
    {
        private readonly PlanetExplorationDbContext _context;
        public DiscoveryController(PlanetExplorationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<RequestResult<List<DiscoveryFormDto>>>> GetDiscoveries()
        {
            var query = new GetDiscoveries_Query(_context);
            return await query.ExecuteAsync();
        }
        // GET: api/discovery/types
        [HttpGet("types")]
        public async Task<ActionResult<RequestResult<List<DiscoveryType>>>> GetDiscoveryTypes()
        {
            var query = new GetDiscoveryTypes_Query(_context);
            return await query.ExecuteAsync();
        }
        [HttpPost]
        public async Task<RequestResult<int>> CreateDiscovery(DiscoveryFormDto discovery)
        {
            var cmd = new CreateDiscovery_Command(_context, discovery);
            return await cmd.ExecuteAsync();
        }
        // GET: api/discovery/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<RequestResult<DiscoveryFormDto>>> GetDiscovery(int id) //IActionResult was wrong and no return type was specified
        {
            var query = new GetDiscoveryById_Query(_context, id);
            return await query.ExecuteAsync();
        }

        // PUT: api/discovery/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<RequestResult<int>>> UpdateDiscovery(int id, [FromBody]DiscoveryFormDto discover) // was missing Task ,async and return type
        {
            var cmd = new UpdateDiscoveryById_Command(_context, id, discover);
            return await cmd.ExecuteAsync();
        }

        // DELETE: api/discovery/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult<RequestResult<int>>> DeleteDiscovery(int id) // was missing Task, async and return type
        {
            var cmd = new DeleteDiscovery_Command(_context, id);
            return await cmd.ExecuteAsync();
        }
    }
}
