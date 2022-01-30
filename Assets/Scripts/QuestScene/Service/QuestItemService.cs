using DefaultNamespace.Common;
using DefaultNamespace.model;

namespace DefaultNamespace.Service
{
    public class QuestItemService
    {
        public static void AddItemToInventory(InventoryItem item, int amount)
        {
            var itemIdToAmount = GlobalSerializedState.Get().AddedInventoryItems;

            if (itemIdToAmount.Contains(item.id))
            {
                itemIdToAmount[item.id] += amount;
            } else
            {
                itemIdToAmount[item.id] = amount;
            }
        }
    }
}