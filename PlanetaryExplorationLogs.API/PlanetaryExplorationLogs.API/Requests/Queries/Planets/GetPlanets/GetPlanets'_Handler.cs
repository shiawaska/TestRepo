using Microsoft.EntityFrameworkCore;
using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Data.DTO;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

namespace PlanetaryExplorationLogs.API.Requests.Queries.Planets.GetMissions
{
    public class GetPlanets_Handler : HandlerBase<List<PlanetFormDto>>
	{
		

		public GetPlanets_Handler(PlanetExplorationDbContext context)
			: base(context)
		{			
		}

        public override async Task<RequestResult<List<PlanetFormDto>>> HandleAsync()
        {
            var planets = await DbContext.Planets
                .OrderBy(p => p.Name)
                .Select(selector: static p => new PlanetFormDto
                {
                    Name = p.Name,
                    Type = p.Type,
                    Climate = p.Climate,
                    Terrain = p.Terrain,
                    Population = p.Population,
                }).ToListAsync();

            var result = new RequestResult<List<PlanetFormDto>>
            {
                Data = planets
            };

            return result;
        }
	}

	
	

	
	
	

}
