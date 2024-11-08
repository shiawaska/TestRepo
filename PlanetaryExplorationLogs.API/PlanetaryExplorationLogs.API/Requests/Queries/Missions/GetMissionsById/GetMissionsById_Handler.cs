using Microsoft.EntityFrameworkCore;
using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Data.Models;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;
using System.Net;

namespace PlanetaryExplorationLogs.API.Requests.Queries.Missions.GetMissionsById
{
    // The handler class is responsible for executing the query
    public class GetMissionsById_Handler : HandlerBase<Mission>
    {
        private readonly int _missionId;

        public GetMissionsById_Handler(PlanetExplorationDbContext context, int MissionId)
            : base(context)
        {
            _missionId = MissionId;
        }

        public override async Task<RequestResult<Mission>> HandleAsync()
        {
            
            var someMission = await DbContext.Missions.FindAsync(_missionId);
           

            // Return the data
            var result = new RequestResult<Mission> { Data = someMission };

            return result;
        }
    }
    
   
}
