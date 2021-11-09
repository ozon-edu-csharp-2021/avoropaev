using System.Collections.Generic;
using MerchandiseService.Models;

namespace MerchandiseService.Controllers.ResponseModel
{
    public class MerchandiseResponse
    {
        public MerchandiseResponse(int merchId, MerchPack merchPack, List<Item> items)
        {
            MerchPack = merchPack;
            Items = items;
            MerchId = merchId;
        }

        public int MerchId { get; }

        public List<Item> Items { get; }
        
        public MerchPack MerchPack { get; }
    }
    
    public enum MerchPack
    {
        WelcomePack,
        StarterPack,
        ConferenceListenerPack,
        ConferenceSpeakerPack,
        VeteranPack
    }
}