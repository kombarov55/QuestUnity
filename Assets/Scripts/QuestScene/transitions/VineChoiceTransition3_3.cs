using DefaultNamespace.MainPanel;
using DefaultNamespace.model;

namespace DefaultNamespace.transitions
{
    public class VineChoiceTransition3_3 : Transition
    {
        public VineChoiceTransition3_3(string questNodeId, int choiceNum) : base(questNodeId, choiceNum)
        {
        }

        public override void run(QuestNode currentQuestNode, int clickedChoiceNum, QuestSceneFlow questSceneFlow)
        {
            MainPanelController mainPanelController = questSceneFlow.mainPanelController;
            QuestPanelController questPanelController = questSceneFlow.questPanelController;
            CachedUserData cachedUserData = questSceneFlow.cachedUserData;
            
            int coinCount = cachedUserData.coinCount;
            
            if (coinCount >= 1)
            {
                mainPanelController.decrementCoinCount();
                questPanelController.displayQuestNode("3.3");
            } else 
            { 
                questPanelController.displayQuestNode("3.2");
            }
        }
    }
}