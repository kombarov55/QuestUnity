using System.Xml;
using DefaultNamespace.model;

namespace DefaultNamespace
{
    public class XmlHelper
    {
        public static string GetValue(XmlNode elem, string name)
        {
            XmlNode node = getChildByName(elem, name);
            return node.InnerText;
        }
        
        public static InventoryItemGameType GetGameType(XmlNode xmlNode, string name) 
        {
            InventoryItemGameType forWhatGame;
            InventoryItemGameType.TryParse(XmlHelper.GetValue(xmlNode, "ForWhatGame"), true, out forWhatGame);
            return forWhatGame;
        }

        public static XmlNode getChildByName(XmlNode elem, string name)
        {
            for (var i = 0; i < elem.ChildNodes.Count; i++)
            {
                var child = elem.ChildNodes[i];
                if (child.Name == name)
                {
                    return child;
                }
            }

            return null;
        }
    }
}