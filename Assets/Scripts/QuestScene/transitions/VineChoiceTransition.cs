using DefaultNamespace.model;

namespace DefaultNamespace.transitions
{
    public class VineChoiceTransition : Transition
    {
        public VineChoiceTransition(string questNodeId, int choiceNum) : base(questNodeId, choiceNum)
        {
        }

        public override void run(QuestNode currentQuestNode, int clickedChoiceNum, QuestSceneController questSceneController)
        {
            int coinCount = questSceneController.cachedUserData.coinCount;
            
            if (coinCount >= 1)
            {
                questSceneController.decrementCoinCount();
                questSceneController.displayQuestNode("3.0");
            } else 
            { 
                questSceneController.displayQuestNode("3.2");
            }
        }
    }
}