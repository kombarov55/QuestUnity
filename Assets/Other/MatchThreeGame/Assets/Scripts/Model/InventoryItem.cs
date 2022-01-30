using DefaultNamespace.Common;

namespace Other.MatchThreeGame.Assets.Scripts.Model
{
    public class InventoryItem
    {
        public ThreeInARowItemTemplate ItemTemplate;
        public Observable<int> Amount;

        public InventoryItem(ThreeInARowItemTemplate itemTemplate, int amount)
        {
            ItemTemplate = itemTemplate;
            Amount = new Observable<int>(amount);
        }
    }
}