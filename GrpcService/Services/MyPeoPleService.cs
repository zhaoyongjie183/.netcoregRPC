using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using GrpcService.Data;
using Microsoft.Extensions.Logging;


namespace GrpcService
{
    public class MyPeoPleService :PeoPleService.PeoPleServiceBase
    {
        public override Task<PeopleNoResponse> GetPeoPleNo(PeoPleNoRequest request, ServerCallContext context)
        {
            var c = InMemoryData.peopleModels.Where(x => x.Id == request.Id).FirstOrDefault();

            PeopleNoResponse peopleNoResponse = new PeopleNoResponse();

            peopleNoResponse.People = c;

           return  Task.FromResult(peopleNoResponse);
        }
    }
}
