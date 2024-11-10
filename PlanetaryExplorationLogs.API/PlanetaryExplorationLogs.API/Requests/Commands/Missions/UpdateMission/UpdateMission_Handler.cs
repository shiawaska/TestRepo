using Microsoft.EntityFrameworkCore;
using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Data.DTO;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;
using System.Net;

namespace PlanetaryExplorationLogs.API.Requests.Commands.Missions.UpdateMission
{
    public class UpdateMission_Command_Handler : HandlerBase<int>
    {
        private readonly MissionFormDto _MissionUpdate;
        private readonly int _Id;

        public UpdateMission_Command_Handler(PlanetExplorationDbContext context, int Id, MissionFormDto MissionUpdate)
            : base(context)
        {
            _MissionUpdate = MissionUpdate;
            _Id = Id;
        }

        public override async Task<RequestResult<int>> HandleAsync()
        {

            var DbMission = await DbContext.Missions.FindAsync(_Id); // get the mission to update via its id

            DbMission.Name = _MissionUpdate.Name;
            DbMission.Date = _MissionUpdate.Date;
            DbMission.PlanetId = _MissionUpdate.PlanetId;
            DbMission.Description = _MissionUpdate.Description; 
            await DbContext.SaveChangesAsync(); // save changes to the database
            var result = new RequestResult<int> // return the updated mission id
            {
                Data = DbMission.Id,
                StatusCode = HttpStatusCode.OK
            };

            return result;
        }
    }
}
