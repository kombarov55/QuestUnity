using System.Collections.Generic;
using System.Xml;
using DefaultNamespace;
using DefaultNamespace.model;
using UnityEngine;

namespace QuestScene.Repositories
{
    public class InventoryItemsRepository
    {

        private static List<InventoryItem> list = new List<InventoryItem>();
        
        public static List<InventoryItem> getAll()
        {
            if (list.Count == 0)
            {
                list = load();
            }

            return list;
        }

        public static InventoryItem findById(string id)
        {
            var items = getAll();
            foreach (var inventoryItem in items)
            {
                if (inventoryItem.id == id)
                {
                    return inventoryItem;
                }
            }

            return null;
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
        

        private static List<InventoryItem> load()
        {
            TextAsset textAsset = (TextAsset) Resources.Load("Inventory");
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.LoadXml(textAsset.text);
            XmlNodeList xmlNodes = xmldoc.GetElementsByTagName("InventoryItem");

            List<InventoryItem> result = new List<InventoryItem>();

            for (var i = 0; i < xmlNodes.Count; i++)
            {
                var xmlNode = xmlNodes[i];

                var item = new InventoryItem();
                item.id = XmlHelper.GetValue(xmlNode, "Id");
                item.name = XmlHelper.GetValue(xmlNode, "Name");
                item.description = XmlHelper.GetValue(xmlNode, "Description");
                item.imgPath = XmlHelper.GetValue(xmlNode, "ImgPath");

                result.Add(item);
            }

            return result;
        }
    }
}