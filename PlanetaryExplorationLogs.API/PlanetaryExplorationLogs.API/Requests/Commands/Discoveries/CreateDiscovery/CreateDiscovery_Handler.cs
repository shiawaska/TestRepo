using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Data.DTO;
using PlanetaryExplorationLogs.API.Data.Models;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

namespace PlanetaryExplorationLogs.API.Requests.Commands.Discoveries.CreateDiscovery
{
    public class CreateDiscovery_Handler : HandlerBase<int>
	{
		private readonly DiscoveryFormDto _Discovery;

		public CreateDiscovery_Handler(PlanetExplorationDbContext context, DiscoveryFormDto Discovery)
            : base(context)
        {
            _Discovery = Discovery;
        }
		

		public override async Task<RequestResult<int>> HandleAsync()
		{
			
			Discovery DiscoveryModel = new Discovery // Mapping DTO to Model
            {
                MissionId = _Discovery.MissionId,
                DiscoveryTypeId = _Discovery.DiscoveryTypeId,
                Name = _Discovery.Name,
                Description = _Discovery.Description,
                Location = _Discovery.Location,
            };
			await DbContext.Discoveries.AddAsync(DiscoveryModel);
            await DbContext.SaveChangesAsync();

            var result = new RequestResult<int>
			{
				Data = DiscoveryModel.Id,
            };

			return result;
		}
	}

}
