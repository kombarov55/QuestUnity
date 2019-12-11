using System.Collections.Generic;
using DefaultNamespace.transitions;
using UnityEngine;

namespace DefaultNamespace
{
    public class TransitionService : MonoBehaviour
    {
        public QuestPanelController questPanelController;
        
        private List<Transition> transitions = new List<Transition>();
        private Transition defaultTransition = new DefaultTransition();

        public void Start()
        {
            transitions.Add(new VineChoiceTransition("3", 0, "3.1"));
            transitions.Add(new VineChoiceTransition("3.1", 0, "3.1"));
            transitions.Add(new VineChoiceTransition("3.3", 1, "3.3"));
            
            transitions.Add(new PortraitTransition("3", 1, "3.1"));
            transitions.Add(new PortraitTransition("3.1", 2, "3.1"));
            transitions.Add(new PortraitTransition("3.2", 3, "3.2"));
            transitions.Add(new PortraitTransition("3.3", 3, "3.3"));
            transitions.Add(new PortraitTransition("3.4", 1, "3.4"));
        }

        public void init()
        {
            
        }

        public Transition find(string questNodeId, int choiceNum)
        {
            foreach (var transition in transitions)
            {
                if (transition.questNodeId == questNodeId && transition.choiceNum == choiceNum)
                {
                    return transition;
                }
            }

            return defaultTransition;
        }
    }
}