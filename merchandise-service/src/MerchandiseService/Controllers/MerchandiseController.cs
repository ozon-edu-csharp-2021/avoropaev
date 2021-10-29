using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MerchandiseService.Controllers.ResponseModel;
using MerchandiseService.Services.Interfaces;
using MerchPack = MerchandiseService.Controllers.ResponseModel.MerchPack;

namespace MerchandiseService.Controllers
{
    [ApiController]
    [Route("api/Merchandise")]
    [Produces("application/json")]
    public class MerchandiseController : ControllerBase
    {
        private readonly IMerchandiseService _merchandiseService;

        public MerchandiseController(IMerchandiseService merchandiseService)
        {
            _merchandiseService = merchandiseService;
        }
        
        [HttpGet("{merchId:long}")]
        public async Task<ActionResult<MerchandiseResponse>> GetMerchandiseById(int merchId, CancellationToken token)
        {
            var merchandise = await _merchandiseService.GetMerchandiseByID(merchId, token);
            if (merchandise is null)
            {
                return NotFound();
            }
            MerchandiseResponse merchandiseResponse = new MerchandiseResponse(merchandise.MerchId,
                (MerchPack) merchandise.MerchPack, merchandise.Items);
            return merchandiseResponse;
        }

        [HttpGet]
        public async Task<ActionResult<List<MerchandiseResponse>>> GetInformationAboutIssueMerchandise(CancellationToken token)
        {
            var stockItems = await _merchandiseService.GetInformationAboutIssueMerchandise(token);
            return Ok(stockItems);
        }
    }
}