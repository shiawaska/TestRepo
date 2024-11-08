using PlanetaryExplorationLogs.API.Data.Models;
using Microsoft.EntityFrameworkCore;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using PlanetaryExplorationLogs.API.Data.Context;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

namespace PlanetaryExplorationLogs.API.Requests.Queries.Discoveries.GetDiscoveryTypes
{
    public class GetDiscoveryTypes_Handler : HandlerBase<List<DiscoveryType>>
    {
        public GetDiscoveryTypes_Handler(PlanetExplorationDbContext context)
            : base(context)
        {
        }

        public override async Task<RequestResult<List<DiscoveryType>>> HandleAsync()
        {
            var discoveryTypes = await DbContext.DiscoveryTypes
                .OrderBy(t => t.Name)
                .ToListAsync();

            var result = new RequestResult<List<DiscoveryType>> 
            { 
                Data = discoveryTypes 
            };

            return result;
        }
    }

}
