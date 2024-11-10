using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Data.DTO;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using System.Net;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

namespace PlanetaryExplorationLogs.API.Requests.Commands.Missions.CreateMission
{
	public class CreateMission_Command : RequestBase<int>
	{
		private readonly MissionFormDto _newMission;

		public CreateMission_Command(PlanetExplorationDbContext context, MissionFormDto NewMission)
			: base(context)
		{
			_newMission = NewMission;
		}
		
		public override IValidator Validator =>
			new CreateMission_Validator(DbContext, _newMission);

		
		public override IHandler<int> Handler =>
			new CreateMission_Handler(DbContext, _newMission);
	}

	
	


}
