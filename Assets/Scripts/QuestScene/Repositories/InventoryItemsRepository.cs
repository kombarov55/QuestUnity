using System.Collections.Generic;
using System.Linq;
using System.Xml;
using DefaultNamespace;
using DefaultNamespace.model;
using DefaultNamespace.Model;
using UnityEngine;

namespace QuestScene.Repositories
{
    public class InventoryItemsRepository
    {

        private static List<InventoryItem> list = new List<InventoryItem>();

        public static List<StoredItem> getAllStoredItems()
        {
            return GetAll()
                .Select(v => new StoredItem(v, 1, false))
                .ToList();
        }
        
        public static List<InventoryItem> GetAll()
        {
            if (list.Count == 0)
            {
                list = Load();
            }

            return list;
        }

        public static InventoryItem findById(string id)
        {
            var items = GetAll();
            foreach (var inventoryItem in items)
            {
                if (inventoryItem.id == id)
                {
                    return inventoryItem;
                }
            }

            return null;
        }

        public static List<InventoryItem> FindItemsForSaleByGameType(InventoryItemGameType gameType)
        {
            return GetAll().Where(v => v.forWhatGame == gameType && v.canBeBought).ToList();
        }

        public static List<InventoryItem> findOpened(List<string> openedItemsIds)
        {
            List<InventoryItem> result = new List<InventoryItem>();
            foreach (var id in openedItemsIds)
            {
                var item = findById(id);
                if (item != null)
                {
                    result.Add(item);
                }
            }
            return result;
        }
        

        private static List<InventoryItem> Load()
        {
            return Resources.LoadAll<TextAsset>("Items")
                .Select(textAsset => JsonUtility.FromJson<JSONItems>(textAsset.text).data)
                .SelectMany(list => list)
                .ToList();
        }
    }
}