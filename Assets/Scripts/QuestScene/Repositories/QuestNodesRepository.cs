using System;
using System.Collections.Generic;
using System.Xml;
using DefaultNamespace;
using DefaultNamespace.model;
using UnityEngine;

namespace QuestScene.Repositories
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

                node.id = XmlHelper.getValue(xmlNode, "Id");
                node.imgPath = XmlHelper.getValue(xmlNode, "ImgPath");
                node.description = XmlHelper.getValue(xmlNode, "Description");
                node.choices = new List<QuestNodeChoice>();

                XmlNodeList xmlNodeListChoices = XmlHelper.getChildByName(xmlNode, "Choices").ChildNodes;
                for (var i1 = 0; i1 < xmlNodeListChoices.Count; i1++)
                {
                    XmlNode choiceXmlNode = xmlNodeListChoices[i1];

                    var choice = new QuestNodeChoice();
                    try
                    {
                        choice.text = XmlHelper.getValue(choiceXmlNode, "Text");
                        choice.nextId = XmlHelper.getValue(choiceXmlNode, "NextId");
                    }
                    catch (Exception)
                    {
                        Debug.Log("ошибка в вызове XmlHelper.GetValue у nodeId=" + node.id);
                    }

                    node.choices.Add(choice);
                }

                result.Add(node);
            }

            return result;
        }
    }
    
    
}
