using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Data.DTO;
using PlanetaryExplorationLogs.API.Data.Models;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using System.Net;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

namespace PlanetaryExplorationLogs.API.Requests.Commands.Missions.UpdateMission
{

	//// Paste these using statements at the top of the file and uncomment them
	//using PlanetaryExplorationLogs.API.Data.Context;
	//using PlanetaryExplorationLogs.API.Utility.Patterns;
	//using System.Net;
	//using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

	  public class UpdateMission_Command : RequestBase<int>
    {
        private readonly MissionFormDto _Mission;
        private readonly int _Id;

        public UpdateMission_Command(PlanetExplorationDbContext context, int Id, MissionFormDto MissionUpdate)
            : base(context)
        {
            _Mission = MissionUpdate;
            _Id = Id;
        }

        // The validator is optional and can be removed if not needed
        public override IValidator Validator =>
            new UpdateMission_Validator(DbContext, _Id, _Mission);

        // The handler is mandatory to have for every command
        public override IHandler<int> Handler =>
            new UpdateMission_Command_Handler(DbContext, _Id, _Mission);
    }

	// The authorizer class is responsible for any additional authorization logic
	

	// The validator class is responsible for validating things before the query is executed
	

	// The handler class is responsible for executing the query
	

}
