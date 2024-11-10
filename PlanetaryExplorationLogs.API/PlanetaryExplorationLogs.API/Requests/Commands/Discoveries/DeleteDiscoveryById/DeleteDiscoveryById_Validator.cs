using Microsoft.EntityFrameworkCore;
using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;
using System.Net;

namespace PlanetaryExplorationLogs.API.Requests.Commands.Discoveries.DeleteDiscoveryById
{
    public class DeleteDiscovery_Validator : ValidatorBase
    {
        private readonly int _Id;

        public DeleteDiscovery_Validator(PlanetExplorationDbContext context, int Id)
            : base(context)
        {
            _Id = Id;
        }

        public override async Task<RequestResult> ValidateAsync()
        {



            if (_Id < 0)
            {
                return await InvalidResultAsync(
                    HttpStatusCode.BadRequest,
                    "invalid input for id");
            }
            var discoveryExists = await DbContext.Discoveries.FindAsync(_Id);
            if (discoveryExists == null)
            {
                return await InvalidResultAsync(
                    HttpStatusCode.NotFound,
                    "Discovery not found");

            }


            return await ValidResultAsync();
        }
    }
}
