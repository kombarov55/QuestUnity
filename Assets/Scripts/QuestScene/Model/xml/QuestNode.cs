using System.Collections.Generic;

namespace DefaultNamespace.model
{
    public class QuestNode
    {
        public string id;
        public string title;
        public string imgPath;
        public string description;
        public List<QuestNodeChoice> choices;
    }
}