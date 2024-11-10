using Microsoft.EntityFrameworkCore;
using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using System.Net;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

namespace PlanetaryExplorationLogs.API.Requests.Queries.Discoveries.GetDiscoveries
{
    public class GetDiscoveries_Validator : ValidatorBase
	{
		private readonly string _someFilter;

		public GetDiscoveries_Validator(PlanetExplorationDbContext context)
			: base(context)
		{
			
		}

		public override async Task<RequestResult> ValidateAsync()
		{
            var DiscoveriesExists = await DbContext.Discoveries
				.OrderByDescending(t => t.Name)
				.ToListAsync();
			if (DiscoveriesExists == null)
			{
                return await InvalidResultAsync(
                    HttpStatusCode.NotFound,
                    "No discoveries found");

            }

                return await ValidResultAsync();
		}
	}

}
