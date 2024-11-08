using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;
using System.Net;
using PlanetaryExplorationLogs.API.Data.Models;

namespace PlanetaryExplorationLogs.API.Requests.Commands.Missions.CreateMission
{
    public class CreateMission_Validator : ValidatorBase
    {
        private readonly Mission _newMission;

        public CreateMission_Validator(PlanetExplorationDbContext context, Mission NewMission)
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
                    "missing Mission information");
            }
            // check if requred is present and check length
            //check each property in the model and see if the attributes have any requirements for those properties


            
            return await ValidResultAsync();
        }
    }
}
