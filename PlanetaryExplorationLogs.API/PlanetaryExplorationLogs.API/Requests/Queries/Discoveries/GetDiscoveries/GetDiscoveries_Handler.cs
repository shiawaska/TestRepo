using Microsoft.EntityFrameworkCore;
using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Data.DTO;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

namespace PlanetaryExplorationLogs.API.Requests.Queries.Discoveries.GetDiscoveries
{
    public class GetDiscoveries_Handler : HandlerBase<List<DiscoveryFormDto>>
	{
		

		public GetDiscoveries_Handler(PlanetExplorationDbContext context)
			: base(context)
		{
			
		}

		public override async Task<RequestResult<List<DiscoveryFormDto>>> HandleAsync()
		{
            var Discoveries = await DbContext.Discoveries
                
                .Select(d => new DiscoveryFormDto
                {
                    MissionId = d.MissionId,
                    DiscoveryTypeId = d.DiscoveryTypeId,
                    Name = d.Name,
                    Description = d.Description,
                    Location = d.Location,
                })
                .ToListAsync();

            var result = new RequestResult<List<DiscoveryFormDto>>
            {
                Data = Discoveries
            };            

			return result;
		}
	}

}
