using Microsoft.EntityFrameworkCore;
using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Data.DTO;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

namespace PlanetaryExplorationLogs.API.Requests.Queries.Missions.GetDiscoveriesByMission
{
    public class GetDiscoveriesByMission_Handler : HandlerBase<List<DiscoveryFormDto>>
	{
		private readonly int _MissionId;

		public GetDiscoveriesByMission_Handler(PlanetExplorationDbContext context, int missionId)
			: base(context)
		{
			_MissionId = missionId;
		}

		public override async Task<RequestResult<List<DiscoveryFormDto>>> HandleAsync()
		{
			var Discoveries = await DbContext.Discoveries
                .Where(d => d.MissionId == _MissionId)
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
