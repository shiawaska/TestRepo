using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Data.DTO;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using System.Net;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

namespace PlanetaryExplorationLogs.API.Requests.Queries.Discoveries.GetDiscoveryById
{
    public class GetDiscoveryById_Handler : HandlerBase<DiscoveryFormDto>
    {
        private readonly int _Id;

        public GetDiscoveryById_Handler(PlanetExplorationDbContext context, int Id)
            : base(context)
        {
            _Id = Id;
        }

        public override async Task<RequestResult<DiscoveryFormDto>> HandleAsync()
        {
            var DiscoveryModel = await DbContext.Discoveries.FindAsync(_Id);

            if (DiscoveryModel == null)
            {
                return new RequestResult<DiscoveryFormDto>
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Message = "Discovery not found"
                };
            }

            DiscoveryFormDto DiscoveryById = new DiscoveryFormDto
            {
                MissionId = DiscoveryModel.MissionId,
                DiscoveryTypeId = DiscoveryModel.DiscoveryTypeId,
                Name = DiscoveryModel.Name,
                Description = DiscoveryModel.Description,
                Location = DiscoveryModel.Location,
            };

            var result = new RequestResult<DiscoveryFormDto>
            {
                Data = DiscoveryById
            };

            return result;
        }
    }

}
