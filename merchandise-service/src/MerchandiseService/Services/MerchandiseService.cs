using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MerchandiseService.Models;
using MerchandiseService.Services.Interfaces;

namespace MerchandiseService.Services
{
    public class MerchandiseService : IMerchandiseService
    {
        private readonly List<Merchandise> _merchandises = new List<Merchandise>();

        public Task<Merchandise> GetMerchandiseByID(int merchId, CancellationToken _)
        {
            var merchandise = _merchandises.FirstOrDefault(x => x.MerchId == merchId);
            return Task.FromResult(merchandise);
        }

        public Task<List<Merchandise>> GetInformationAboutIssueMerchandise(CancellationToken _)
        {
            return Task.FromResult(_merchandises);
        }
    }
}