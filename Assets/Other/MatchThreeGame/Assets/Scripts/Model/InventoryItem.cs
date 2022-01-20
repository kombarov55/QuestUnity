using DefaultNamespace.Common;

namespace Other.MatchThreeGame.Assets.Scripts.Model
{
    public class InventoryItem
    {
        public ItemTemplate ItemTemplate;
        public Observable<int> Amount;

        public InventoryItem(ItemTemplate itemTemplate, int amount)
        {
            ItemTemplate = itemTemplate;
            Amount = new Observable<int>(amount);
        }
    }
}