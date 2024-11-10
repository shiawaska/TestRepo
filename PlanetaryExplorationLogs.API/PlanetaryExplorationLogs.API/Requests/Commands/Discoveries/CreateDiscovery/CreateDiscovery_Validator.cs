using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Data.DTO;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using System.Net;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

namespace PlanetaryExplorationLogs.API.Requests.Commands.Discoveries.CreateDiscovery
{
    public class CreateDiscovery_Validator : ValidatorBase
	{
		private readonly DiscoveryFormDto _Discovery;

		public CreateDiscovery_Validator(PlanetExplorationDbContext context, DiscoveryFormDto Discovery)
			: base(context)
		{
			_Discovery = Discovery;
		}

		public override async Task<RequestResult> ValidateAsync()
		{
			
			if (_Discovery == null)
            {
                return await InvalidResultAsync(
                    HttpStatusCode.BadRequest,
                    "Discovery Form Incomplete");
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
                    "Discovery Description is missing or too long");
            }
            if (string.IsNullOrEmpty(_Discovery.Location) || _Discovery.Location.Length > 150)
            {
                return await InvalidResultAsync(
                    HttpStatusCode.BadRequest,
                    "Discovery Location is missing or too long");
            }
            var MissionExists = DbContext.Missions.FindAsync(_Discovery.MissionId);
            if (MissionExists == null)
            {
                return await InvalidResultAsync(
                    HttpStatusCode.BadRequest,
                    "Your chosen mission does not exist");
            }
            var DiscoveryTypeExists = DbContext.DiscoveryTypes.FindAsync(_Discovery.DiscoveryTypeId);
            if (DiscoveryTypeExists == null)
            {
                return await InvalidResultAsync(
                    HttpStatusCode.BadRequest,
                    "Discovery Type does not Exists");
            }

            return await ValidResultAsync();
		}
	}

}
