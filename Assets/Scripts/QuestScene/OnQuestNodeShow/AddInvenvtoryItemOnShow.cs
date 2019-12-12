namespace DefaultNamespace.OnQuestNodeShow
{
    public class AddItenvtoryItemOnShow : OnQuestNodeShow
    {
        private string itemName;
        
        public AddItenvtoryItemOnShow(string questNodeId, string itemName) : base(questNodeId)
        {
            this.itemName = itemName;
        }

        public override void run(QuestSceneFlow questSceneFlow)
        {
            questSceneFlow.mainPanelController.setStatusLineText("Предмет (" + itemName + ") добавлен в инвентарь!");
        }
    }
}