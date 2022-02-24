using DefaultNamespace.Common;

namespace Other.MatchThreeGame.Assets.Scripts.Model
{
    public class StoredItem
    {
        public ThreeInARowItemTemplate ItemRepository;
        public Observable<int> Amount;

        public StoredItem(ThreeInARowItemTemplate itemRepository, int amount)
        {
            ItemRepository = itemRepository;
            Amount = new Observable<int>(amount);
        }
    }
}