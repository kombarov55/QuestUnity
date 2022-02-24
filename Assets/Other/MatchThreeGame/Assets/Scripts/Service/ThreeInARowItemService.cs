using System.Collections.Generic;
using System.Linq;
using DefaultNamespace.Common;
using Other.MatchThreeGame.Assets.Scripts.Model;

namespace Other.MatchThreeGame.Assets.Scripts.Service
{
    public class ThreeInARowItemService
    {
        public List<StoredItem> GetAddedItems()
        {
            var itemIdToAmount = GlobalSerializedState.Get().AddedInventoryItems.GetCopy();

            return itemIdToAmount
                .Where(pair => ItemRepository.ItemIdToItemTemplate.ContainsKey(pair.Key))
                .Select(pair => new StoredItem(ItemRepository.ItemIdToItemTemplate[pair.Key], pair.Value))
                .ToList();
        }
    }
}