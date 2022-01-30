using DefaultNamespace.Common;
using DefaultNamespace.model;

namespace DefaultNamespace.Service
{
    public class ShopService
    {
        public static bool IsEnoughMoney(InventoryItem item)
        {
            return GlobalSerializedState.Get().CoinCount.Value >= item.price;
        }

        public static void Purchase(InventoryItem item)
        {
            if (IsEnoughMoney(item))
            {
                var state = GlobalSerializedState.Get();
                state.CoinCount.Value -= item.price;
                
            }
        }
    }
}