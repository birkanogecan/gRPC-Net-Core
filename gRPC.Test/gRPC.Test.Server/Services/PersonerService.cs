using Grpc.Core;
using Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gRPC.Test.Server.Services
{
    public class PersonerService : Personer.PersonerBase
    {

        public override Task<PersonReply> GetPerson(PersonRequest request, ServerCallContext context)
        {
            return Task.FromResult(new PersonReply
            {
                Name = "Birkan Ögecan"
            });
        }

    }
}
