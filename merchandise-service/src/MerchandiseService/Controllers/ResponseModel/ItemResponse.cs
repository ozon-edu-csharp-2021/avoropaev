namespace MerchandiseService.Controllers.ResponseModel
{
    public class ItemResponse
    {
        public ItemResponse(KindOfItem kindOfItem)
        {
            KindOfItem = kindOfItem;
        }
        public KindOfItem KindOfItem { get; }
    }
    
    
    public enum KindOfItem
    {
        Tshirt,
        Hoodie,
        Notebook,
        Backpack,
        Pen,
        Cup
    }
}