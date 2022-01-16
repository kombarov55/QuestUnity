using System.Xml;

namespace DefaultNamespace
{
    public class XmlHelper
    {
        public static string GetValue(XmlNode elem, string name)
        {
            XmlNode node = getChildByName(elem, name);
            return node.InnerText;
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