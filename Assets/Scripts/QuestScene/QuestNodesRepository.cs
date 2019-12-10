using System.Collections.Generic;
using System.Xml;
using DefaultNamespace.model;
using UnityEngine;

namespace DefaultNamespace
{
    public class QuestNodesRepository : MonoBehaviour
    {

        public string pathToQuestNodes = "QuestNodes";

        private List<QuestNode> data;

        public void Start()
        {
            data = load();
        }
        
        public List<QuestNode> getAll()
        {
            if (data == null)
            {
                data = load();
            }
            
            return data;
        }

        public QuestNode findById(string id)
        {
            foreach (var questNode in getAll())
            {
                if (questNode.id == id)
                {
                    return questNode;
                }
            }

            return null;
        }
        
        private List<QuestNode> load() 
        {
            TextAsset textAsset = (TextAsset) Resources.Load(pathToQuestNodes);  
            XmlDocument xmldoc = new XmlDocument ();
            xmldoc.LoadXml (textAsset.text);
            XmlNodeList questNodes = xmldoc.GetElementsByTagName("QuestNode");

            List<QuestNode> result = new List<QuestNode>(); 
            
            for (var i = 0; i < questNodes.Count; i++)
            {
                XmlNode xmlNode = questNodes[i];
                
                var node = new QuestNode();

                node.id = getValue(xmlNode, "Id");
                node.imgPath = getValue(xmlNode, "ImgPath");
                node.description = getValue(xmlNode, "Description");
                node.choices = new List<QuestNodeChoice>();

                XmlNodeList xmlNodeListChoices = getChildByName(xmlNode, "Choices").ChildNodes;
                for (var i1 = 0; i1 < xmlNodeListChoices.Count; i1++)
                {
                    XmlNode choiceXmlNode = xmlNodeListChoices[i1];

                    var choice = new QuestNodeChoice();
                    choice.text = getValue(choiceXmlNode, "Text");
                    choice.nextId = getValue(choiceXmlNode, "NextId");
                    
                    node.choices.Add(choice);
                }

                result.Add(node);
            }

            return result;
        }

        private string getValue(XmlNode elem, string name)
        {
            XmlNode node = getChildByName(elem, name);
            return node.InnerText;
        }

        private XmlNode getChildByName(XmlNode elem, string name)
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
