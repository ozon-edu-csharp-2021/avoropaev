using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MerchandiseService.Models;

namespace MerchandiseService.Services.Interfaces
{
    public interface IMerchandiseService
    {
        Task<Merchandise> GetMerchandiseByID(int merchId, CancellationToken token);

        Task<List<Merchandise>> GetInformationAboutIssueMerchandise(CancellationToken token);
    }
}