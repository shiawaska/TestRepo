using Microsoft.EntityFrameworkCore;
using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Data.Models;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;
using System.Net;
using PlanetaryExplorationLogs.API.Data.DTO;

namespace PlanetaryExplorationLogs.API.Requests.Queries.Missions.GetMissionsById
{
    // The handler class is responsible for executing the query
    public class GetMissionsById_Handler : HandlerBase<MissionFormDto>
    {
        private readonly int _missionId;

        public GetMissionsById_Handler(PlanetExplorationDbContext context, int MissionId)
            : base(context)
        {
            _missionId = MissionId;
        }

        public override async Task<RequestResult<MissionFormDto>> HandleAsync()
        {
            
            var someMission = await DbContext.Missions.FindAsync(_missionId);
            MissionFormDto Mission = new MissionFormDto
            {
                Name = someMission.Name,
                Date = someMission.Date,
                PlanetId = someMission.PlanetId,
                Description = someMission.Description
            };
            // and discoveries? revisit during front end implementation

            // Return the data
            var result = new RequestResult<MissionFormDto> { Data = Mission };

            return result;
        }
    }
    
   
}
