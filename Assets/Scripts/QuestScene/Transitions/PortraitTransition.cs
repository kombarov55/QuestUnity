using DefaultNamespace.AnimationPanel;
using DefaultNamespace.model;

namespace DefaultNamespace.transitions
{
    public class PortraitTransition : Transition
    {

        private string nextId;
        
        public PortraitTransition(string questNodeId, int choiceNum, string nextId) : base(questNodeId, choiceNum)
        {
            this.nextId = nextId;
        }

        public override void run(QuestNode currentQuestNode, int clickedChoiceNum, QuestSceneFlow questSceneFlow)
        {
            // Показать анимацию с портретом
            // вернуться на сл экран 

            AnimationPanelController animationPanelController = questSceneFlow.animationPanelController;
            QuestPanelController questPanelController = questSceneFlow.questPanelController;
            animationPanelController.show("Images/Portrait", () =>
            {
                questPanelController.displayQuestNode(nextId);
            });
        }
    }
}