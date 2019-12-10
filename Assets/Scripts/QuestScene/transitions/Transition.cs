using DefaultNamespace.model;

namespace DefaultNamespace.transitions
{
    /**
 * Применяется при выборе такого то questNOdeId и choiceNum. Функция которой передаётся текущий QuestNode, выбранный номер, контроллер
 */
    public abstract class Transition
    {
        public int choiceNum;
        public string questNodeId;

        public Transition(int choiceNum, string questNodeId)
        {
            this.choiceNum = choiceNum;
            this.questNodeId = questNodeId;
        }

        public abstract void run(QuestNode currentQuestNode, int clickedChoiceNum, QuestSceneController questSceneController);

    }
}