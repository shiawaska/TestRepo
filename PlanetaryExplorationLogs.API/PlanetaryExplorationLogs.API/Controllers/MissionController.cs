using Microsoft.AspNetCore.Mvc;
using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Data.Models;
using PlanetaryExplorationLogs.API.Requests.Queries.Missions.GetMissions;
using PlanetaryExplorationLogs.API.Requests.Queries.Missions.GetMissionsById;
using PlanetaryExplorationLogs.API.Utility.Patterns;

namespace PlanetaryExplorationLogs.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MissionController : ControllerBase
    {
        private readonly PlanetExplorationDbContext _context;
        public MissionController(PlanetExplorationDbContext context)
        {
            _context = context;
        }

        // GET: api/mission
        [HttpGet]
        public async Task<ActionResult<RequestResult<List<Mission>>>> GetMissions()
        {
            var query = new GetMissions_Query(_context);
            return await query.ExecuteAsync();
        }

        // GET: api/mission/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<RequestResult<Mission>>> GetMission(int id)
        {
            var query = new GetMissionsById_Query(_context, id);
            return await query.ExecuteAsync();
            
        }

        // POST: api/mission
        [HttpPost]
        public async Task<ActionResult<RequestResult<int>>> CreateMission([FromBody] Mission mission)
        {
            // Create a new mission.
            return StatusCode(501); // Not Implemented
        }

        //// PUT: api/mission
        //[HttpPut]
        //public async Task<ActionResult<RequestResult<int>>> UpdateMission([FromBody] Mission mission)
        //{
        //    // Update an existing mission.
        //    return StatusCode(501); // Not Implemented
        //}

        //// DELETE: api/mission/{id}
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<RequestResult<int>>> DeleteMission(int id)
        //{
        //    // Delete a mission by ID.
        //    return StatusCode(501); // Not Implemented
        //}

        //// GET: api/mission/{missionId}/discovery
        //[HttpGet("{missionId}/discovery")]
        //public async Task<ActionResult<RequestResult<List<Discovery>>>> GetDiscoveriesForMission(int missionId)
        //{
        //    // Retrieve all discoveries for a specific mission.
        //    return StatusCode(501); // Not Implemented
        //}

        //// POST: api/mission/{missionId}/discovery
        //[HttpPost("{missionId}/discovery")]
        //public async Task<ActionResult<RequestResult<int>>> CreateDiscoveryForMission(int missionId, [FromBody] Discovery discovery)
        //{
        //    // Create a new discovery under a specific mission.
        //    return StatusCode(501); // Not Implemented
        //}

    }
}
