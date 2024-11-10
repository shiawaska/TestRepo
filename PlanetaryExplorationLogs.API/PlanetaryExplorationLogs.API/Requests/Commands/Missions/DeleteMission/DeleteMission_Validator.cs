using Microsoft.EntityFrameworkCore;
using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;
using System.Net;

namespace PlanetaryExplorationLogs.API.Requests.Commands.Missions.DeleteMission
{
    public class DeleteMission_Validator : ValidatorBase
    {
        private readonly int _Id;

        public DeleteMission_Validator(PlanetExplorationDbContext context, int Id)
            : base(context)
        {
            _Id = Id;
        }

        public override async Task<RequestResult> ValidateAsync()
        {
            // Obviously, this is dummy validation logic. Replace it with your own.
            await Task.CompletedTask;

            if (_Id <= 0)
            {
                return await InvalidResultAsync(
                    HttpStatusCode.BadRequest,
                    "Invalid Id.");
            }
            Console.WriteLine($"id being searched [{_Id}]");
            var IdExists = await DbContext.Missions.FindAsync(_Id);
            Console.WriteLine($"Results of search [{IdExists}]");
            if (IdExists == null)
            {
                return await InvalidResultAsync(
                    HttpStatusCode.BadRequest,
                    "Id does not exist.");

            }


            return await ValidResultAsync();
        }
    }
}
