using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;
using System.Net;

namespace PlanetaryExplorationLogs.API.Requests.Queries.Missions.GetMissionsById
{
    
 class GetMissionsById_Validator : ValidatorBase
    {
        private readonly int _missionId;

        public GetMissionsById_Validator(PlanetExplorationDbContext context, int MissionId)
            : base(context)
        {
            _missionId = MissionId;
        }
        
        public override async Task<RequestResult> ValidateAsync()
        {
            
            
            if (_missionId <= 0) // check if the filter value is valid
            {
                return await InvalidResultAsync(
                    HttpStatusCode.BadRequest,
                    "Filter Value is invalid.");
            }
            var result =  await DbContext.Missions.FindAsync(_missionId); // search for the mission in the database
            if (result == null) // check if the mission exists
            {
                return await InvalidResultAsync(
                    HttpStatusCode.NotFound,
                    "Mission not found.");
            }
            
            return await ValidResultAsync();
        }
    }
    
}
