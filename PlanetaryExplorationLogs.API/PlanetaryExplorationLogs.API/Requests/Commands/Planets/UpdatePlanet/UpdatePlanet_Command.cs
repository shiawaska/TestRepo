using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Data.DTO;
using PlanetaryExplorationLogs.API.Data.Models;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

namespace PlanetaryExplorationLogs.API.Requests.Commands.Planets.UpdatePlanet
{
    public class UpdatePlanet_Command : RequestBase<int>
	{
		private readonly PlanetFormDto _planet;
		private readonly int _id;

		public UpdatePlanet_Command(PlanetExplorationDbContext context, PlanetFormDto planet, int id)
			: base(context)
		{
			_planet = planet;
			_id = id;

		}

		public override IValidator Validator =>
			new UpdatePlanet_Validator(DbContext, _planet, _id );

		public override IHandler<int> Handler =>
			new UpdatePlanet_Handler(DbContext, _planet, _id);
	}
}
