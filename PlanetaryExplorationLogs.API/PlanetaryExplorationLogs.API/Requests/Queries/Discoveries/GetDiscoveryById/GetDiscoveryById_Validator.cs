using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using System.Net;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

namespace PlanetaryExplorationLogs.API.Requests.Queries.Discoveries.GetDiscoveryById
{
    public class GetDiscoveryById_Validator : ValidatorBase
    {
        private readonly int _Id;

        public GetDiscoveryById_Validator(PlanetExplorationDbContext context, int Id)
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
