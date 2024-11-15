using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using System.Net;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

namespace PlanetaryExplorationLogs.API.Requests.Queries.Missions.GetDiscoveriesByMission
{
    public class GetDiscoveriesByMission_Validator : ValidatorBase
	{
		private readonly int _MissionId;

		public GetDiscoveriesByMission_Validator(PlanetExplorationDbContext context, int missionId)
			: base(context)
		{
			_MissionId = missionId;
		}

		public override async Task<RequestResult> ValidateAsync()
		{
			if (_MissionId == null)
            {
                return await InvalidResultAsync(					
					HttpStatusCode.BadRequest,
					"Mission id is missing");
            }
			var MissionExists = await DbContext.Missions.FindAsync(_MissionId);
			if (MissionExists == null)
			{
				return await InvalidResultAsync(
					HttpStatusCode.NotFound,
					"Mission not found");
			}
			//if (MissionExists.Discoveries.Count == 0)
			//{
			//	return await InvalidResultAsync(
			//		HttpStatusCode.NotFound,
			//		"No discoveries found for this mission");
			//}


                return await ValidResultAsync();
		}
	}

}
