using System.Net;
using System.Threading.Tasks;
using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Data.DTO;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

namespace PlanetaryExplorationLogs.API.Requests.Commands.Missions.UpdateMission
{
    
    public class UpdateMission_Validator : ValidatorBase
    {
        private readonly MissionFormDto _MissionUpdate;
        private readonly int _Id;

        public UpdateMission_Validator(PlanetExplorationDbContext context, int Id, MissionFormDto MissionUpdate)
            : base(context)
        {
            _MissionUpdate = MissionUpdate;
            _Id = Id;
        }

        public override async Task<RequestResult> ValidateAsync()
        {

            if (_MissionUpdate == null)
            {
                return await InvalidResultAsync(
                    HttpStatusCode.BadRequest,
                    "Missing too much Mission information");
            }
            if (string.IsNullOrEmpty(_MissionUpdate.Name) || _MissionUpdate.Name.Length > 150)
            {
                return await InvalidResultAsync(
                    HttpStatusCode.BadRequest,
                    "Mission Name is missing or too long");
            }
            DateTime today = DateTime.Now;
            if (_MissionUpdate.Date > today)
            {
                return await InvalidResultAsync(
                    HttpStatusCode.BadRequest,
                    "Mission Date must be in the past");
            }
            
            if (_MissionUpdate.PlanetId < 0)
            {
                return await InvalidResultAsync(
                    HttpStatusCode.BadRequest,
                    "Mission must have a planet");
            }
            var PlanetExists = await DbContext.Missions.FindAsync(_MissionUpdate.PlanetId);
            if (PlanetExists == null)
            {
                return await InvalidResultAsync(
                    HttpStatusCode.BadRequest,
                    "Planet Id does not exist.");
            }
            if (string.IsNullOrEmpty(_MissionUpdate.Description) || _MissionUpdate.Description.Length > 500)
            {
                return await InvalidResultAsync(
                    HttpStatusCode.BadRequest,
                    "Mission Description is missing or too long");
            }
            if (_Id < 0)
            {
                return await InvalidResultAsync(
                    HttpStatusCode.BadRequest,
                    "Id value is not valid.");
            }
            // query the database where id = _Id and validate the mission id exsts in the database
           
            var IdExists = await DbContext.Missions.FindAsync(_Id);
            
            if (IdExists == null)
            {
                return await InvalidResultAsync(
                    HttpStatusCode.BadRequest,
                    "Mission Id does not exist.");
            }

            // You can also check things in the database, if needed, such as checking if a record exists
            return await ValidResultAsync();
        }
    }
}
