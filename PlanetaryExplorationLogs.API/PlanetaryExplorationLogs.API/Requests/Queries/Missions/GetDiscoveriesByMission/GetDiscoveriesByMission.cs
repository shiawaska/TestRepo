using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Data.DTO;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

namespace PlanetaryExplorationLogs.API.Requests.Queries.Missions.GetDiscoveriesByMission
{

    

    public class GetDiscoveriesByMission_Command : RequestBase<List<DiscoveryFormDto>>
	{
		private readonly int _MissionId;

		public GetDiscoveriesByMission_Command(PlanetExplorationDbContext context, int missionId)
			: base(context)
		{
			_MissionId = missionId;
		}

		
		public override IValidator Validator =>
			new GetDiscoveriesByMission_Validator(DbContext, _MissionId);

		// The handler is mandatory to have for every command
		public override IHandler<List<DiscoveryFormDto>> Handler =>
			new GetDiscoveriesByMission_Handler(DbContext, _MissionId);
	}

}
