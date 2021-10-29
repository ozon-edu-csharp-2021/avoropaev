using System.Linq;
using System.Threading.Tasks;
using Google.Protobuf.Collections;
using Grpc.Core;
using MerchandiseService.Grpc;
using MerchandiseService.Services.Interfaces;

namespace MerchandiseService.GrpcServices
{
    public class MerchandiseServiceGrpcService : MerchandiseServiceGrpc.MerchandiseServiceGrpcBase
    {
        private readonly IMerchandiseService _merchandiseService;

        public MerchandiseServiceGrpcService(IMerchandiseService merchandiseService)
        {
            _merchandiseService = merchandiseService;
        }

        public override async Task<GetInformationAboutIssueMerchandiseResponse> GetInformationAboutIssueMerchandise(GetInformationAboutIssueMerchandiseRequest request, 
            ServerCallContext context)
        {
            var merchandises = await _merchandiseService.GetInformationAboutIssueMerchandise(context.CancellationToken);
            return new GetInformationAboutIssueMerchandiseResponse
            {
                Merchandises = { merchandises.Select(x=> new GetInformationAboutIssueMerchandiseResponseUnit
                {
                    MerchId = x.MerchId,
                    Item = {  } // ??
                })}
            };
        }

        public override async Task<GetMerchandiseByIDResponse> GetMerchandiseByID(GetMerchandiseByIDRequest request, ServerCallContext context)
        {
            var merchandise = await _merchandiseService.GetMerchandiseByID(request.MerchId, context.CancellationToken);
            return new GetMerchandiseByIDResponse()
            {
                MerchId = merchandise.MerchId,
                Item = { } // ??
            };
        }
    }
}