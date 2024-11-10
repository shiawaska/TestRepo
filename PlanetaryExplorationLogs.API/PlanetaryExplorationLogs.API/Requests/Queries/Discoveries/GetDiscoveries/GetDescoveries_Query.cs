using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Data.DTO;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

namespace PlanetaryExplorationLogs.API.Requests.Queries.Discoveries.GetDiscoveries
{



    public class GetDiscoveries_Query : RequestBase<List<DiscoveryFormDto>>
	{
		

		public GetDiscoveries_Query(PlanetExplorationDbContext context)
			: base(context)
		{			
		}

		
		public override IValidator Validator => new GetDiscoveries_Validator(DbContext);

		
		public override IHandler<List<DiscoveryFormDto>> Handler => new GetDiscoveries_Handler(DbContext);
	}

}
