using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using System.Net;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

namespace PlanetaryExplorationLogs.API.Requests.Commands.Missions.DeleteMission
{

	//// Paste these using statements at the top of the file and uncomment them
	//using PlanetaryExplorationLogs.API.Data.Context;
	//using PlanetaryExplorationLogs.API.Utility.Patterns;
	//using System.Net;
	//using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

	public class DeleteMission_Command : RequestBase<int>
	{
		private readonly int _Id;

		public DeleteMission_Command(PlanetExplorationDbContext context, int Id)
			: base(context)
		{
			_Id = Id;
		}

		
		public override IValidator Validator =>
			new DeleteMission_Validator(DbContext, _Id);

		// The handler is mandatory to have for every command
		public override IHandler<int> Handler =>
			new DeleteMission_Handler(DbContext, _Id);
	}

	

}
