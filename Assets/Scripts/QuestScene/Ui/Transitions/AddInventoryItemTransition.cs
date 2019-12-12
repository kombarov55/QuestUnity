using DefaultNamespace.MainPanel;
using DefaultNamespace.model;

namespace DefaultNamespace.transitions
{
    public class AddInventoryItemTransition : Transition
    {
        private string itemName;
        private string nextNodeId;
        
        public AddInventoryItemTransition(string questNodeId, int choiceNum, string itemName, string nextNodeId) : base(questNodeId, choiceNum)
        {
            this.itemName = itemName;
        }

        public override void run(QuestNode currentQuestNode, int clickedChoiceNum, QuestSceneFlow questSceneFlow)
        {
            // добавить в инвентарь предмет. Перейти на сл. сцену
            questSceneFlow.mainPanelController.setStatusLineText("Предмет (" + itemName + ") добавлен в инвентарь!");
            questSceneFlow.questPanelController.displayQuestNode(nextNodeId);
        }
    }
}