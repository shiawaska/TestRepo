using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Data.DTO;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

namespace PlanetaryExplorationLogs.API.Requests.Commands.Discoveries.UpdateDiscoveryById
{
    public class UpdateDiscoveryById_Handler : HandlerBase<int>
	{
		private readonly int _Id;
        private readonly DiscoveryFormDto _Discovery;

        public UpdateDiscoveryById_Handler(PlanetExplorationDbContext context, int id, DiscoveryFormDto discovery)
            : base(context)
        {
            _Id = id;
            _Discovery = discovery;
        }
		

		public override async Task<RequestResult<int>> HandleAsync()
		{
			var discoveryModel = await DbContext.Discoveries.FindAsync(_Id);
            discoveryModel.Name = _Discovery.Name;
            discoveryModel.Description = _Discovery.Description;
            discoveryModel.Location = _Discovery.Location;
            DbContext.Discoveries.Update(discoveryModel);
            await DbContext.SaveChangesAsync();

            

            var result = new RequestResult<int>
			{
				Data = discoveryModel.Id
            };

			return result;
		}
	}

}
