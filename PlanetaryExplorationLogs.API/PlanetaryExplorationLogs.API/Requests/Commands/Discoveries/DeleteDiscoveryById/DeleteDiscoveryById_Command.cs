using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using System.Net;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

namespace PlanetaryExplorationLogs.API.Requests.Commands.Discoveries.DeleteDiscoveryById
{ 
        public class DeleteDiscovery_Command : RequestBase<int>
        {
            private readonly int _Id;

            public DeleteDiscovery_Command(PlanetExplorationDbContext context, int Id)
                : base(context)
            {
                _Id = Id;
            }


            public override IValidator Validator =>
                new DeleteDiscovery_Validator(DbContext, _Id);


            public override IHandler<int> Handler =>
                new DeleteDiscovery_Handler(DbContext, _Id);
        }



       
        

        
        

    

}
