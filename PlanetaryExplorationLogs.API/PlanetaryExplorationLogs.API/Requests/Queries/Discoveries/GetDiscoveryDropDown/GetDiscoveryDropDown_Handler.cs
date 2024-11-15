using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Data.DTO;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

namespace PlanetaryExplorationLogs.API.Requests.Queries.Discoveries.GetDiscoveryDropDown
{
    public class GetDiscoveryDropDown_Handler : HandlerBase<List<DiscoveryDropDownDto>>
	{
		

		public GetDiscoveryDropDown_Handler(PlanetExplorationDbContext context)
			: base(context)
		{
			
		}

		public override async Task<RequestResult<List<DiscoveryDropDownDto>>> HandleAsync()
		{
			
			var query = DbContext.Discoveries.Select(x => new DiscoveryDropDownDto
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();

            var result = new RequestResult<List<DiscoveryDropDownDto>> { Data = query };

			return result;
		}
	}

}