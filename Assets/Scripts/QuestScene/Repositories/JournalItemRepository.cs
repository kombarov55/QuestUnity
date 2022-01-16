using System.Collections.Generic;
using System.Xml;
using DefaultNamespace.model;
using UnityEngine;

namespace DefaultNamespace.JournalPanel
{
    public class JournalItemRepository : MonoBehaviour
    {
        public string pathToJournalItems = "Journal";

        private List<JournalItem> data;

        public List<JournalItem> getAll()
        {
            if (data == null)
            {
                data = load();
            }

            return data;
        }

        public JournalItem findById(string id)
        {
            foreach (var journalItem in getAll())
            {
                if (journalItem.id == id)
                {
                    return journalItem;
                }
            }

            return null;
        }

        private List<JournalItem> load()
        {
            TextAsset textAsset = (TextAsset) Resources.Load(pathToJournalItems);  
            XmlDocument xmldoc = new XmlDocument ();
            xmldoc.LoadXml (textAsset.text);
            XmlNodeList xmlNodes = xmldoc.GetElementsByTagName("JournalItem");

            List<JournalItem> result = new List<JournalItem>();
            
            for (var i = 0; i < xmlNodes.Count; i++)
            {
                var xmlNode = xmlNodes[i];
                
                var journalItem = new JournalItem();
                journalItem.id = XmlHelper.GetValue(xmlNode, "Id");
                journalItem.title = XmlHelper.GetValue(xmlNode, "Title");
                journalItem.description = XmlHelper.GetValue(xmlNode, "Description");
                journalItem.imgPath =  XmlHelper.GetValue(xmlNode, "ImgPath");
                
                result.Add(journalItem);
            }

            return result;
        }
    }
}