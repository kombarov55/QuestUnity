using DefaultNamespace.AnimationPanel;
using DefaultNamespace.MainPanel;
using DefaultNamespace.model;

namespace DefaultNamespace.transitions
{
    public class PortraitTransition : Transition
    {

        private string nextId;

        public PortraitTransition(string questNodeId, string choiceText, string choiceNextId, string nextId) : base(questNodeId, choiceText, choiceNextId)
        {
            this.nextId = nextId;
        }

        public override void run(QuestNode currentQuestNode, QuestNodeChoice selectedChoice,
            QuestSceneFlow questSceneFlow)
        {
            // Показать анимацию с портретом
            // вернуться на сл экран 

            AnimationPanelController animationPanelController = questSceneFlow.animationPanelController;
            QuestPanelController questPanelController = questSceneFlow.questPanelController;
            MainPanelController mainPanelController = questSceneFlow.mainPanelController;
            
            animationPanelController.show("Images/Portrait", () =>
            {
                questPanelController.displayQuestNode(nextId);
                questSceneFlow.mainPanelController.openJournalItem("Портрет");
            });
        }
    }
}