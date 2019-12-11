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
            transitions.Add(new VineChoiceTransition("3", 0));
            transitions.Add(new VineChoiceTransition("3.1", 0));
        }

        public void init(QuestPanelController questPanelController)
        {
            this.questPanelController = questPanelController;
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