using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;
using System.Net;
using PlanetaryExplorationLogs.API.Data.DTO;


namespace PlanetaryExplorationLogs.API.Requests.Commands.Missions.CreateMission
{
    public class CreateMission_Validator : ValidatorBase
    {
        private readonly MissionFormDto _newMission;

        public CreateMission_Validator(PlanetExplorationDbContext context, MissionFormDto NewMission)
            : base(context)
        {
            _newMission = NewMission;
        }

        public override async Task<RequestResult> ValidateAsync()
        {
            if (_newMission == null)
            {
                return await InvalidResultAsync(
                    HttpStatusCode.BadRequest,
                    "Missing too much Mission information");
            }
            if (string.IsNullOrEmpty(_newMission.Name) || _newMission.Name.Length > 150)
            {
                return await InvalidResultAsync(
                    HttpStatusCode.BadRequest,
                    "Mission Name is missing or too long");
            }
            DateTime today = DateTime.Now;
            if (_newMission.Date > today)
            {
                return await InvalidResultAsync(
                    HttpStatusCode.BadRequest,
                    "Mission Date must be in the past");
            }
            if (_newMission.PlanetId <= 0)
            {
                return await InvalidResultAsync(
                    HttpStatusCode.BadRequest,
                    "Mission must have a planet");
            }
            var PlanetExists = await DbContext.Missions.FindAsync(_newMission.PlanetId);
            if (PlanetExists == null)
            {
                return await InvalidResultAsync(
                    HttpStatusCode.BadRequest,
                    "Planet Id does not exist.");
            }
            if (string.IsNullOrEmpty(_newMission.Description) || _newMission.Description.Length > 500)
            {
                return await InvalidResultAsync(
                    HttpStatusCode.BadRequest,
                    "Mission Description is missing or too long");
            }

            return await ValidResultAsync();
        }
    }
}
