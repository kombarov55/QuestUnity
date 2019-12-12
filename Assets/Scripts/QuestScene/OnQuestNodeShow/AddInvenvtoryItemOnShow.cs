namespace DefaultNamespace.OnQuestNodeShow
{
    public class AddInventoryItemOnShow : OnQuestNodeShow
    {
        private string itemName;
        
        public AddInventoryItemOnShow(string questNodeId, string itemName) : base(questNodeId)
        {
            this.itemName = itemName;
        }

        public override void run(QuestSceneFlow questSceneFlow)
        {
            questSceneFlow.mainPanelController.setStatusLineText("Предмет (" + itemName + ") добавлен в инвентарь!");
        }
    }
}