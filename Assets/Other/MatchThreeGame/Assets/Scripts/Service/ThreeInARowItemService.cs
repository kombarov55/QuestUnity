using System.Collections.Generic;
using System.Linq;
using DefaultNamespace.Common;
using Other.MatchThreeGame.Assets.Scripts.Model;

namespace Other.MatchThreeGame.Assets.Scripts.Service
{
    public class ThreeInARowItemService
    {
        public List<InventoryItem> GetInventoryItems()
        {
            var itemIdToAmount = GlobalSerializedState.Get().AddedInventoryItems.GetCopy();

            return itemIdToAmount
                .Select(pair => new InventoryItem(ThreeInARowItems.ItemIdToItemTemplate[pair.Key], pair.Value))
                .ToList();
        }
    }
}