using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Data.DTO;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

namespace PlanetaryExplorationLogs.API.Requests.Queries.Missions.GetMissionDropdownDto
{


	public class GetMissionDropDownDto_Query : RequestBase<List<MissionDropDownDto>>
	{
		

		public GetMissionDropDownDto_Query(PlanetExplorationDbContext context)
			: base(context)
		{			
		}
		
		public override IHandler<List<MissionDropDownDto>> Handler => new GetMissionDropDownDto_Handler(DbContext);
	}

	// The handler class is responsible for executing the query
	public class GetMissionDropDownDto_Handler : HandlerBase<List<MissionDropDownDto>>
	{
		

		public GetMissionDropDownDto_Handler(PlanetExplorationDbContext context)
			: base(context)
		{			
		}

		public override async Task<RequestResult<List<MissionDropDownDto>>> HandleAsync()
		{
			var query = DbContext.Missions
				.Select(m => new MissionDropDownDto
				{
					Id = m.Id,
					Name = m.Name
				}).ToList();
			
            var result = new RequestResult<List<MissionDropDownDto>> 
			{ Data =  query };

			return result;
		}
	}

	
}


