using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Data.Models;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using System.Net;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

namespace PlanetaryExplorationLogs.API.Requests.Commands.Missions.CreateMission
{
    public class CreateMission_Handler : HandlerBase<int>
    {
        private readonly Mission _newMission;

        public CreateMission_Handler(PlanetExplorationDbContext context, Mission NewMission)
            : base(context)
        {
            _newMission = NewMission;
        }

        public override async Task<RequestResult<int>> HandleAsync()
        {
            var newMission = new Mission
            {
                 Name = _newMission.Name,
                 Date = _newMission.Date,
                 PlanetId = _newMission.PlanetId, // ok due to being a foreign key
                Description = _newMission.Description,
                 // panetid sets the planet
            };
            await DbContext.Missions.AddAsync(newMission);
            await DbContext.SaveChangesAsync();
            var result = new RequestResult<int>
            {
                Data = newMission.Id,
                StatusCode = HttpStatusCode.Created
            };
            return result;
        }
    }
}
