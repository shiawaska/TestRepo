using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Data.DTO;
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

        public override IValidator Validator => new GetPlanetById_Validator(DbContext, _id);
        public override IHandler<PlanetFormDto> Handler => new GetPlanetById_Handler(DbContext, _id);
	}

	

}



