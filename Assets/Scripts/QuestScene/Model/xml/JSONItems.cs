using System;
using System.Collections.Generic;

namespace DefaultNamespace.model
{
    [Serializable]
    public class JSONItems
    {
        public List<InventoryItem> data = new List<InventoryItem>();
    }
}