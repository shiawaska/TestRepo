using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Data.DTO;
using PlanetaryExplorationLogs.API.Data.Models;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using System.Net;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

namespace PlanetaryExplorationLogs.API.Requests.Commands.Planets.UpdatePlanet
{
    public class UpdatePlanet_Handler : HandlerBase<int>
	{
		private readonly PlanetFormDto _planet;
		private readonly int _id;

		public UpdatePlanet_Handler(PlanetExplorationDbContext context, PlanetFormDto planet, int id)
            : base(context)
        {
            _planet = planet;
            _id = id;
        }

         public override async Task<RequestResult<int>> HandleAsync()
		{
			Planet updatedPlanet = await DbContext.Planets.FindAsync( _id);
			if (updatedPlanet != null)
			{               
				updatedPlanet.Name = _planet.Name;
                updatedPlanet.Type = _planet.Type;
                updatedPlanet.Population = _planet.Population;
                updatedPlanet.Climate = _planet.Climate;
                updatedPlanet.Terrain = _planet.Terrain;
                await DbContext.SaveChangesAsync();
            }


            // Return the data
            var result = new RequestResult<int>
            {
                Data = _id,
                StatusCode = HttpStatusCode.OK
            };

			return result;
		}
	}

}
