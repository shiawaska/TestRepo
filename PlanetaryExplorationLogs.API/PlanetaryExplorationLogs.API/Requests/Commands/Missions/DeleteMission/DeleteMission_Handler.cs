using Microsoft.EntityFrameworkCore;
using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

namespace PlanetaryExplorationLogs.API.Requests.Commands.Missions.DeleteMission
{
    public class DeleteMission_Handler : HandlerBase<int>
    {
        private readonly int _Id;

        public DeleteMission_Handler(PlanetExplorationDbContext context, int Id)
            : base(context)
        {
            _Id = Id;
        }

        public override async Task<RequestResult<int>> HandleAsync()
        {
            var mission = await DbContext.Missions.FindAsync(_Id);
            if (mission != null)
            {
                DbContext.Missions.Remove(mission);
                await DbContext.SaveChangesAsync();
            }
                       
            var result = new RequestResult<int>
            {
                Data = 0
            };

            return result;
        }
    }
}
