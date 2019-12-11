using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace.OnQuestNodeShow
{
    public class OnQuestNodeShowService : MonoBehaviour
    {
        private List<OnQuestNodeShow> list = new List<OnQuestNodeShow>(); 
        private OnQuestNodeShow defaultOnQuestNodeShow = new DefaultOnQuestNodeShow();

        public void Start()
        {
            list.Add(new OpenDiaryNoteOnShow("Письмо", "Детские воспоминания"));
            list.Add(new OpenDiaryNoteOnShow("2.1", "Монстры и мост"));
            list.Add(new OpenDiaryNoteOnShow("3.3", "Древнее сокровище"));
        }
        
        public OnQuestNodeShow findOnQuestNodeShow(string questNodeId)
        {

            if (list.Count == 0)
            {
                Start();
            }
            
            foreach (var onQuestNodeShow in list)
            {
                if (onQuestNodeShow.questNodeId == questNodeId)
                {
                    return onQuestNodeShow;
                } 
            }

            return defaultOnQuestNodeShow;
        }
    }
}