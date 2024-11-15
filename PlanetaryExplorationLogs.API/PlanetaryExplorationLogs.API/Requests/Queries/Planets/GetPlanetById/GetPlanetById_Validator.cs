using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using System.Net;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

namespace PlanetaryExplorationLogs.API.Requests.Queries.Planets.GetPlanetById
{
    public class GetPlanetById_Validator : ValidatorBase
    {
        private readonly int _id;

        public GetPlanetById_Validator(PlanetExplorationDbContext context, int id)
            : base(context)
        {
            _id = id;
        }

        public override async Task<RequestResult> ValidateAsync()
        {
            var query =  await DbContext.Missions.FindAsync(_id);
            if (query == null)
                {
                return new RequestResult
                {
                    Success = false,
                    Message = "Planet not found",
                    StatusCode = HttpStatusCode.NotFound
                };
            }

            return await ValidResultAsync();
        }
    }

	

}



