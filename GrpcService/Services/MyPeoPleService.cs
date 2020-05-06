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
        public override  Task<PeopleNoResponse> GetPeoPleNo(PeoPleNoRequest request, ServerCallContext context)
        {
            var c = InMemoryData.peopleModels.Where(x => x.Id == request.Id).FirstOrDefault();

            if (c != null)
            {

                PeopleNoResponse peopleNoResponse = new PeopleNoResponse();

                peopleNoResponse.People = c;

                return Task.FromResult(peopleNoResponse);
            }

            throw new Exception("未查询到数据");
        }

        public override async Task GetPeoPleAll(PeopleAllRequest request, IServerStreamWriter<PeopleNoResponse> responseStream, ServerCallContext context)
        {
            foreach (var item in InMemoryData.peopleModels)
            {
               await responseStream.WriteAsync(new PeopleNoResponse() { People = item });
            }
        }
    }
}
