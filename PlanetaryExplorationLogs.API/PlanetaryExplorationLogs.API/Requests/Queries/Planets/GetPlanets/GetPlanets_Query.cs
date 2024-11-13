using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Data.DTO;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

namespace PlanetaryExplorationLogs.API.Requests.Queries.Planets.GetMissions
{



    public class GetPlanets_Query : RequestBase<List<PlanetFormDto>>
	{
		

		public GetPlanets_Query(PlanetExplorationDbContext context)
			: base(context)
		{		
		}
		
		public override IHandler<List<PlanetFormDto>> Handler => new GetPlanets_Handler(DbContext);
	}

	
	

	
	
	

}
