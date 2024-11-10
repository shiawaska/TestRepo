using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Data.DTO;
using PlanetaryExplorationLogs.API.Requests.Queries.Discoveries.GetDiscoveryById;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

namespace PlanetaryExplorationLogs.API.Requests.Queries.Discoveries.GetDiscoveryById
{



    public class GetDiscoveryById_Query : RequestBase<DiscoveryFormDto>
    {
        private readonly int _Id;

        public GetDiscoveryById_Query(PlanetExplorationDbContext context, int Id)
            : base(context)
        {
            _Id = Id;
        }


        public override IValidator Validator =>
            new GetDiscoveryById_Validator(DbContext, _Id);


        public override IHandler<DiscoveryFormDto> Handler =>
            new GetDiscoveryById_Handler(DbContext, _Id);
    }

}
