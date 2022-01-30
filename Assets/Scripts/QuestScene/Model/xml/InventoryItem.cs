using System;

namespace DefaultNamespace.model
{
    [Serializable]
    public class InventoryItem
    {
        public string id;
        public string name;
        public string description;
        public string imgPath;
        public InventoryItemGameType forWhatGame;
        public bool canBeBought;
        public int price;
    }
}