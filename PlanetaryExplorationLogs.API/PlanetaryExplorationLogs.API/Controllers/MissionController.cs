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
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PlanetaryExplorationLogs.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MissionController : ControllerBase
    {
        private readonly PlanetExplorationDbContext _context;
        private readonly JsonSerializerOptions _jsonOptions;

        public MissionController(PlanetExplorationDbContext context)
        {
            _context = context;
            _jsonOptions = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                WriteIndented = true
            };
        }

        // GET: api/mission
        [HttpGet]
        public async Task<ActionResult<RequestResult<List<Mission>>>> GetMissions()
        {
            var query = new GetMissions_Query(_context);
            var result = await query.ExecuteAsync();
            return new JsonResult(result, _jsonOptions);
        }

        // GET: api/mission/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<RequestResult<MissionFormDto>>> GetMission(int id)
        {
            var query = new GetMissionsById_Query(_context, id);
            var result = await query.ExecuteAsync();
            return new JsonResult(result, _jsonOptions);
        }

        // POST: api/mission
        [HttpPost]
        public async Task<ActionResult<RequestResult<int>>> CreateMission([FromBody] MissionFormDto mission)
        {
            var cmd = new CreateMission_Command(_context, mission);
            var result = await cmd.ExecuteAsync();
            return new JsonResult(result, _jsonOptions);
        }

        // PUT: api/mission
        [HttpPut("{Id}")]
        public async Task<ActionResult<RequestResult<int>>> UpdateMission(int Id, [FromBody] MissionFormDto MissionUpdate)
        {
            var cmd = new UpdateMission_Command(_context, Id, MissionUpdate);
            var result = await cmd.ExecuteAsync();
            return new JsonResult(result, _jsonOptions);
        }

        // DELETE: api/mission/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult<RequestResult<int>>> DeleteMission(int id)
        {
            var cmd = new DeleteMission_Command(_context, id);
            var result = await cmd.ExecuteAsync();
            return new JsonResult(result, _jsonOptions);
        }

        // GET: api/mission/{missionId}/discovery
        [HttpGet("{missionId}/discovery")]
        public async Task<ActionResult<RequestResult<List<DiscoveryFormDto>>>> GetDiscoveriesForMission(int missionId)
        {
            var cmd = new GetDiscoveriesByMission_Command(_context, missionId);
            var result = await cmd.ExecuteAsync();
            return new JsonResult(result, _jsonOptions);
        }
    }

    }

