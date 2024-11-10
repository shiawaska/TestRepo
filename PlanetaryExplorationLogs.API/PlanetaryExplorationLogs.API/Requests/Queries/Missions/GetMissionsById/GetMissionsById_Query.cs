using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Data.DTO;
using PlanetaryExplorationLogs.API.Data.Models;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

namespace PlanetaryExplorationLogs.API.Requests.Queries.Missions.GetMissionsById
{
    
	

	public class GetMissionsById_Query : RequestBase<MissionFormDto>
	{
		private readonly int _missionId;

		public GetMissionsById_Query(PlanetExplorationDbContext context, int MissionId)
			: base(context)
		{
			_missionId = MissionId;
		}
		
		public override IValidator Validator => new GetMissionsById_Validator(DbContext, _missionId);

		
		public override IHandler<MissionFormDto> Handler => new GetMissionsById_Handler(DbContext, _missionId);
	}

	

}
