using DefaultNamespace.model;

namespace DefaultNamespace.Model
{
    public struct StoredItem
    {
        public InventoryItem Item;
        public int Amount;
        public bool isUnseen;

        public StoredItem(InventoryItem item, int amount, bool isUnseen)
        {
            Item = item;
            Amount = amount;
            this.isUnseen = isUnseen;
        }
    }
}