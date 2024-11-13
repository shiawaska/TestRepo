using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Data.DTO;
using PlanetaryExplorationLogs.API.Data.Models;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using System.Net;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

namespace PlanetaryExplorationLogs.API.Requests.Commands.Planets.UpdatePlanet
{
    public class UpdatePlanet_Validator : ValidatorBase
	{
		private readonly PlanetFormDto _planet;
        private readonly int _id;

        public UpdatePlanet_Validator(PlanetExplorationDbContext context, PlanetFormDto planet, int id)
			: base(context)
		{
			_planet = planet;
            _id = id;

        }

		public override async Task<RequestResult> ValidateAsync()
		{
			

           var dbPlanet = await DbContext.Planets.FindAsync(_id);
            if (dbPlanet == null)
            {
                
                return await InvalidResultAsync(
                    HttpStatusCode.NotFound,
                    "Planet not found");
            }



            return await ValidResultAsync();
		}
	}

}
