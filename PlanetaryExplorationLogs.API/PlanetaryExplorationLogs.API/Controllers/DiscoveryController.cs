using Microsoft.AspNetCore.Mvc;
using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Data.Models;
using PlanetaryExplorationLogs.API.Requests.Queries.Discoveries.GetDiscoveryTypes;
using PlanetaryExplorationLogs.API.Utility.Patterns;

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

        // GET: api/discovery/types
        [HttpGet("types")]
        public async Task<ActionResult<RequestResult<List<DiscoveryType>>>> GetDiscoveryTypes()
        {
            var query = new GetDiscoveryTypes_Query(_context);
            return await query.ExecuteAsync();
        }

        // GET: api/discovery/{id}
        [HttpGet("{id}")]
        public IActionResult GetDiscovery(int id)
        {
            // Retrieve a specific discovery by ID.
            return StatusCode(501); // Not Implemented
        }

        // PUT: api/discovery/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateDiscovery(int id, [FromBody]Discovery discovery)
        {
            // Update an existing discovery.
            return StatusCode(501); // Not Implemented
        }

        // DELETE: api/discovery/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteDiscovery(int id)
        {
            // Delete a discovery.
            return StatusCode(501); // Not Implemented
        }
    }
}
