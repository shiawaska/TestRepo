using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Data.DTO;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

namespace PlanetaryExplorationLogs.API.Requests.Commands.Discoveries.CreateDiscovery
{

    public class CreateDiscovery_Command : RequestBase<int>
	{
		private readonly DiscoveryFormDto _Discovery;

		public CreateDiscovery_Command(PlanetExplorationDbContext context, DiscoveryFormDto discovery)
			: base(context)
		{
			_Discovery = discovery;
		}

		public override IValidator Validator =>
			new CreateDiscovery_Validator(DbContext, _Discovery);

		
		public override IHandler<int> Handler =>
			new CreateDiscovery_Handler(DbContext, _Discovery);
	}

}
