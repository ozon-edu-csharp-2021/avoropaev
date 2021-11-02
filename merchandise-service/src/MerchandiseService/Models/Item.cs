namespace MerchandiseService.Models
{
    public class Item
    {
        public Item(KindOfItem kindOfItem)
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