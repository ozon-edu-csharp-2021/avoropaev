namespace MerchandiseService.HttpModel
{
    public class Item
    {
        public Item(KindOfItem kindOfItem)
        {
            KindOfItem = kindOfItem;
        }
        public KindOfItem KindOfItem { get; }
    }
}