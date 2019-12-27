using DefaultNamespace.MainPanel;
using DefaultNamespace.model;

namespace DefaultNamespace.transitions
{
    public class AddInventoryItemTransition : Transition
    {
        private string itemName;
        private string nextNodeId;

        public AddInventoryItemTransition(string questNodeId, string choiceText, string choiceNextId, string itemName, string nextNodeId) : base(questNodeId, choiceText, choiceNextId)
        {
            this.itemName = itemName;
            this.nextNodeId = nextNodeId;
        }

        public override void run(QuestNode currentQuestNode, QuestNodeChoice selectedChoice,
            QuestSceneFlow questSceneFlow)
        {
            // добавить в инвентарь предмет. Перейти на сл. сцену
            questSceneFlow.mainPanelController.addInventoryItem(itemName);
            questSceneFlow.questPanelController.displayQuestNode(nextNodeId);
        }
    }
}