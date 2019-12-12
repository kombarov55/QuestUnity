using DefaultNamespace.AnimationPanel;
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
            AnimationPanelController animationPanelController = questSceneFlow.animationPanelController;

            int coinCount = cachedUserData.coinCount;
            
            if (coinCount >= 1)
            {
                /*
                 1. Показать скример
                 2. Уменьшить количество монет
                 3. Найти сцену после скримера. 
                 4. Изменить в ней id следующего на successId
                 5. Отобразить эту сцену
                 
                 */
                animationPanelController.show("Images/RedEyes", () =>
                {
                    mainPanelController.decrementCoinCount();
                    QuestNode questNode = questPanelController.questNodesRepository.findById("3.0");
                    questNode.choices[0].nextId = successId;
                    questPanelController.displayQuestNode(questNode);
                    mainPanelController.openJournalItem("Красные глаза");
                });
            } else 
            { 
                questPanelController.displayQuestNode("3.2");
            }
        }
    }
}