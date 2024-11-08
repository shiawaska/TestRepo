using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Data.Models;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

namespace PlanetaryExplorationLogs.API.Requests.Queries.Discoveries.GetDiscoveryTypes
{
    public class GetDiscoveryTypes_Query : RequestBase<List<DiscoveryType>>
    {
        public GetDiscoveryTypes_Query(PlanetExplorationDbContext context)
            : base(context)
        {
        }
        
        public override IHandler<List<DiscoveryType>> Handler => new GetDiscoveryTypes_Handler(DbContext);
    }
}
