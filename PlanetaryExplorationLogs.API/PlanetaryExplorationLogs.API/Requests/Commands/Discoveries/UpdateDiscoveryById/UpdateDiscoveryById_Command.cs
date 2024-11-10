using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Data.DTO;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

namespace PlanetaryExplorationLogs.API.Requests.Commands.Discoveries.UpdateDiscoveryById
{



    public class UpdateDiscoveryById_Command : RequestBase<int>
	{
		private readonly int _Id;
        private readonly DiscoveryFormDto _Discovery;

        public UpdateDiscoveryById_Command(PlanetExplorationDbContext context, int id, DiscoveryFormDto discovery)
			: base(context)
		{
			_Discovery = discovery;
            _Id = id;
        }

		
		public override IValidator Validator =>
			new UpdateDiscoveryById_Validator(DbContext, _Id,_Discovery );

		
		public override IHandler<int> Handler =>
			new UpdateDiscoveryById_Handler(DbContext, _Id, _Discovery);
	}

}
