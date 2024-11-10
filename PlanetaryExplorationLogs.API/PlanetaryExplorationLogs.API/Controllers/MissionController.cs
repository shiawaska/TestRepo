using Microsoft.AspNetCore.Mvc;
using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Data.DTO;
using PlanetaryExplorationLogs.API.Data.Models;
using PlanetaryExplorationLogs.API.Requests.Commands.Missions.CreateMission;
using PlanetaryExplorationLogs.API.Requests.Commands.Missions.DeleteMission;
using PlanetaryExplorationLogs.API.Requests.Commands.Missions.UpdateMission;
using PlanetaryExplorationLogs.API.Requests.Queries.Missions.GetDiscoveriesByMission;
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
        public async Task<ActionResult<RequestResult<MissionFormDto>>> GetMission(int id)
        {
            var query = new GetMissionsById_Query(_context, id);
            return await query.ExecuteAsync();
            
        }

        // POST: api/mission
        [HttpPost]
        public async Task<ActionResult<RequestResult<int>>> CreateMission([FromBody] MissionFormDto mission)
        {   
            var cmd = new CreateMission_Command(_context, mission);
            return await cmd.ExecuteAsync();
            
        }

        // PUT: api/mission
        [HttpPut("{Id}")]
        public async Task<ActionResult<RequestResult<int>>> UpdateMission(int Id,[FromBody] MissionFormDto MissionUpdate)
        {   
            
            var cmd = new UpdateMission_Command(_context, Id, MissionUpdate);
            return await cmd.ExecuteAsync();
            
        }

        // DELETE: api/mission/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult<RequestResult<int>>> DeleteMission(int id)
        {
            var cmd = new DeleteMission_Command(_context, id);
            return await cmd.ExecuteAsync();
        }

        // GET: api/mission/{missionId}/discovery
        [HttpGet("{missionId}/discovery")]
        public async Task<ActionResult<RequestResult<List<DiscoveryFormDto>>>> GetDiscoveriesForMission(int missionId)
        {
            var cmd = new GetDiscoveriesByMission_Command(_context, missionId);
            return await cmd.ExecuteAsync();
            
        }

        // POST: api/mission/{missionId}/discovery
        //[HttpPost("{missionId}/discovery")]
        //public async Task<ActionResult<RequestResult<int>>> CreateDiscoveryForMission(int missionId, [FromBody] DiscoveryFormDto discovery)
        //{
        //    // Create a new discovery under a specific mission.
        //    return StatusCode(501); // Not Implemented
        //}

    }
}
