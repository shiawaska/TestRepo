using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Data.DTO;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

namespace PlanetaryExplorationLogs.API.Requests.Queries.Planets.GetPlanetById
{
    public class GetPlanetById_Handler : HandlerBase<PlanetFormDto>
	{
		private readonly int _id;

		public GetPlanetById_Handler(PlanetExplorationDbContext context, int id)
			: base(context)
		{
			_id = id;
		}

		public override async Task<RequestResult<PlanetFormDto>> HandleAsync()
		{
			var query = await DbContext.Planets.FindAsync(_id);
           
            var planet = new PlanetFormDto
			{
                Name = query.Name,
                Type = query.Type,
                Climate = query.Climate,
                Terrain = query.Terrain,
                Population = query.Population

            };
		

            var result = new RequestResult<PlanetFormDto> { Data = planet };

			return result;
		}
	}

	

}



