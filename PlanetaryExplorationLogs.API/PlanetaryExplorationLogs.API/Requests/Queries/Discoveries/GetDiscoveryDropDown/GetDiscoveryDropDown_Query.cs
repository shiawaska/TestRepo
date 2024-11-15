using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Data.DTO;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

namespace PlanetaryExplorationLogs.API.Requests.Queries.Discoveries.GetDiscoveryDropDown
{



    public class GetDiscoveryDropDown_Query : RequestBase<List<DiscoveryDropDownDto>>
	{
		

		public GetDiscoveryDropDown_Query(PlanetExplorationDbContext context)
			: base(context)
		{

		}

		public override IHandler<List<DiscoveryDropDownDto>> Handler => new GetDiscoveryDropDown_Handler(DbContext);
	}

}