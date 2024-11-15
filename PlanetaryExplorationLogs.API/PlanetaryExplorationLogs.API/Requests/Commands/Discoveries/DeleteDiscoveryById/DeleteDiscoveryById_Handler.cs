using Microsoft.EntityFrameworkCore;
using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;
using System.Net;

namespace PlanetaryExplorationLogs.API.Requests.Commands.Discoveries.DeleteDiscoveryById
{
    public class DeleteDiscovery_Handler : HandlerBase<int>
    {
        private readonly int _Id;

        public DeleteDiscovery_Handler(PlanetExplorationDbContext context, int Id)
            : base(context)
        {
            _Id = Id;
        }

        public override async Task<RequestResult<int>> HandleAsync()
        {
            var DiscoveryModel = await DbContext.Discoveries.FindAsync(_Id);

            if (DiscoveryModel == null)
            {
                return new RequestResult<int>
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Message = "Discovery not found"

                };
            }
            DbContext.Discoveries.Remove(DiscoveryModel);
            await DbContext.SaveChangesAsync();


            var result = new RequestResult<int>
            {
                Data = _Id
            };

            return result;
        }
    }
}
