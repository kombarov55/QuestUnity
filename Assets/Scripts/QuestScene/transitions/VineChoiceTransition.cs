using DefaultNamespace.MainPanel;
using DefaultNamespace.model;

namespace DefaultNamespace.transitions
{
    public class VineChoiceTransition : Transition
    {
        private string successId;
        
        public VineChoiceTransition(string questNodeId, int choiceNum, string successId) : base(questNodeId, choiceNum)
        {
            this.successId = successId;
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
                questPanelController.displayQuestNode(successId);
            } else 
            { 
                questPanelController.displayQuestNode("3.2");
            }
        }
    }
}