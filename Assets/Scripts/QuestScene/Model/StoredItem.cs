using DefaultNamespace.model;

namespace DefaultNamespace.Model
{
    public struct StoredItem
    {
        public InventoryItem Item;
        public int Amount;
        
        public StoredItem(InventoryItem item, int amount)
        {
            Item = item;
            Amount = amount;
        }
    }
}