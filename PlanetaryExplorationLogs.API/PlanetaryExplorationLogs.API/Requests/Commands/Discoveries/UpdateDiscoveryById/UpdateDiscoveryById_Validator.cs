using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Data.DTO;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using System.Net;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

namespace PlanetaryExplorationLogs.API.Requests.Commands.Discoveries.UpdateDiscoveryById
{
    public class UpdateDiscoveryById_Validator : ValidatorBase
	{
		private readonly int _Id;
        private readonly DiscoveryFormDto _Discovery;

        public UpdateDiscoveryById_Validator(PlanetExplorationDbContext context, int id, DiscoveryFormDto discovery)
            : base(context)
        {
            _Id = id;
            _Discovery = discovery;
        }      

		public override async Task<RequestResult> ValidateAsync()
		{
			if (_Id < 0)
            {
                return await InvalidResultAsync(
                    HttpStatusCode.BadRequest,
                    "invalid input for id");
            }
            var discoveryExists = await DbContext.Discoveries.FindAsync(_Id);
            if ( discoveryExists == null)
            {
                return await InvalidResultAsync(
                    HttpStatusCode.NotFound,
                    "Discovery not found");
            }
            if (_Discovery == null)
            {
                return await InvalidResultAsync(
                    HttpStatusCode.BadRequest,
                    "Discovery Form not completed");
            }
            if (string.IsNullOrEmpty(_Discovery.Name) || _Discovery.Name.Length > 150)
            {
                return await InvalidResultAsync(
                    HttpStatusCode.BadRequest,
                    "Discovery Name is missing or too long");
			}
			

            if (string.IsNullOrEmpty(_Discovery.Description) || _Discovery.Description.Length > 500)
			{
                return await InvalidResultAsync(
                    HttpStatusCode.BadRequest,
					"Description is too long");
            }

			if (string.IsNullOrEmpty(_Discovery.Location) || _Discovery.Location.Length > 200)
			{
                return await InvalidResultAsync(
                    HttpStatusCode.BadRequest,
                    "Location is too long");

            }

                return await ValidResultAsync();
		}
	}

}
