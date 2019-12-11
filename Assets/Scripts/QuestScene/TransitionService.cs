using System.Collections.Generic;
using DefaultNamespace.transitions;
using UnityEngine;

namespace DefaultNamespace
{
    public class TransitionService : MonoBehaviour
    {
        public QuestSceneController questSceneController;
        
        private List<Transition> transitions = new List<Transition>();
        private Transition defaultTransition = new DefaultTransition();

        public void Start()
        {
            transitions.Add(new VineChoiceTransition("3", 0));
        }

        public void init(QuestSceneController questSceneController)
        {
            this.questSceneController = questSceneController;
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