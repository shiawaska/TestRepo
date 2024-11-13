using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Data.DTO;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using System.Net;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

namespace PlanetaryExplorationLogs.API.Requests.Queries.Planets.GetPlanetById
{

	
	public class GetPlanetById_Query : RequestBase<PlanetFormDto>
	{
		private readonly int _id;

		public GetPlanetById_Query(PlanetExplorationDbContext context, int id)
			: base(context)
		{
			_id = id;
		}

		
		public override IHandler<PlanetFormDto> Handler => new GetPlanetById_Handler(DbContext, _id);
	}

	// The handler class is responsible for executing the query
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
			var query = DbContext.Planets.FindAsync(_id);
            if (query == null)
            {
                return new RequestResult<PlanetFormDto>
                {
                    Success = false,
                    Message = "Planet not found",
                    StatusCode = HttpStatusCode.NotFound
                };
            }
            var planet = new PlanetFormDto
			{
                Name = query.Result.Name,
                Type = query.Result.Type,
                Climate = query.Result.Climate,
                Terrain = query.Result.Terrain,
                Population = query.Result.Population

            };
		

            var result = new RequestResult<PlanetFormDto> { Data = planet };

			return result;
		}
	}

	

}
