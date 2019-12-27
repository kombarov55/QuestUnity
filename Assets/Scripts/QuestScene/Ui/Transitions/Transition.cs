using DefaultNamespace.model;

namespace DefaultNamespace.transitions
{
    /**
 * Применяется при выборе такого то questNOdeId и choiceNum. Функция которой передаётся текущий QuestNode, выбранный номер, контроллер
 */
    public abstract class Transition
    {
        public string choiceText;
        public string choiceNextId;
        public string questNodeId;

        protected Transition(string questNodeId, string choiceText, string choiceNextId)
        {
            this.choiceText = choiceText;
            this.choiceNextId = choiceNextId;
            this.questNodeId = questNodeId;
        }

        public abstract void run(QuestNode currentQuestNode, QuestNodeChoice selectedChoice, QuestSceneFlow questSceneFlow);

    }
}