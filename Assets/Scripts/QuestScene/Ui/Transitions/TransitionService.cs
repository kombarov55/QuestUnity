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
            if (transitions.Count == 0)
            {
                transitions.Add(new HideQuestNodeChoiceTransition("1", "Конюшни", "2"));
                transitions.Add(new HideQuestNodeChoiceTransition("1", "Бордель", "3"));
                transitions.Add(new HideQuestNodeChoiceTransition("1", "Стрельбище", "4"));
                transitions.Add(new HideQuestNodeChoiceTransition("1", "Лаборатория", "5"));
                transitions.Add(new HideQuestNodeChoiceTransition("1", "Погулять по улице", "6"));

                transitions.Add(new VineChoiceTransition("3", "Для начала не отказался бы от вина (1 монета)", "?",
                    "3.1"));
                transitions.Add(new VineChoiceTransition("3.1", "Еще вина (1 монета)", "?", "3.1"));
                transitions.Add(new VineChoiceTransition("3.3", "Этот бред мне трезвым не понять (1 монета)", "?",
                    "3.3"));
                transitions.Add(new FreeVineTransition("3.4", "Выпить.", "?"));

                transitions.Add(new PortraitTransition("3", "Я осмотрюсь", "?", "3.1"));
                transitions.Add(new PortraitTransition("3.1", "Осмотреться", "?", "3.1"));
                transitions.Add(new PortraitTransition("3.2", "Осмотреться", "?", "3.2"));
                transitions.Add(new PortraitTransition("3.3", "Осмотреться", "?", "3.3"));
                transitions.Add(new PortraitTransition("3.4", "Осмотреться", "?", "3.4"));

                transitions.Add(new AddInventoryItemTransition("3.5", "Надо проверить эту башню", "3.6", "Карта и ключ", "3.6"));
            }
        }

        public void init()
        {
            Start();
        }

        public Transition find(string questNodeId, string choiceText, string choiceNextId)
        {
            foreach (var transition in transitions)
            {
                if (transition.questNodeId == questNodeId && transition.choiceText == choiceText &&
                    transition.choiceNextId == choiceNextId)
                {
                    return transition;
                }
            }

            return defaultTransition;
        }
    }
}