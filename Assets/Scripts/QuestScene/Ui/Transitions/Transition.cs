using DefaultNamespace.model;

namespace DefaultNamespace.transitions
{
    /**
 * Применяется при выборе такого то questNOdeId и choiceNum. Функция которой передаётся текущий QuestNode, выбранный номер, контроллер
 */
    public abstract class Transition
    {
        public string choiceText;
        public string nextChoiceId;
        public string questNodeId;

        protected Transition(string questNodeId, string choiceText, string nextChoiceId)
        {
            this.choiceText = choiceText;
            this.nextChoiceId = nextChoiceId;
            this.questNodeId = questNodeId;
        }

        public abstract void run(QuestNode currentQuestNode, QuestNodeChoice selectedChoice, QuestSceneFlow questSceneFlow);

    }
}