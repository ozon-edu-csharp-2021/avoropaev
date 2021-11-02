using System.Collections.Generic;


namespace MerchandiseService.HttpModel
{
    public class Merchandise
    {
        public Merchandise(int merchId, MerchPack merchPack, List<Item> items)
        {
            MerchPack = merchPack;
            Items = items;
            MerchId = merchId;
        }

        public int MerchId { get; }

        public List<Item> Items { get; }
        
        public MerchPack MerchPack { get; }
    }
}