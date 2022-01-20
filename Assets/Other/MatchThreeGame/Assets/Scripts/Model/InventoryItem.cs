namespace Other.MatchThreeGame.Assets.Scripts.Model
{
    public class InventoryItem
    {
        public ItemTemplate ItemTemplate;
        public int Amount;

        public InventoryItem(ItemTemplate itemTemplate, int amount)
        {
            ItemTemplate = itemTemplate;
            Amount = amount;
        }
    }
}