using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Data.Models;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using System.Net;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

namespace PlanetaryExplorationLogs.API.Requests.Commands.Missions.CreateMission
{
	public class CreateMission_Command : RequestBase<int>
	{
		private readonly Mission _newMission;

		public CreateMission_Command(PlanetExplorationDbContext context, Mission NewMission)
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
