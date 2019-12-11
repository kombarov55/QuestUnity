using DefaultNamespace.AnimationPanel;
using DefaultNamespace.model;

namespace DefaultNamespace.transitions
{
    public class PortraitTransition3_1 : Transition
    {
        public PortraitTransition3_1(string questNodeId, int choiceNum) : base(questNodeId, choiceNum)
        {
        }

        public override void run(QuestNode currentQuestNode, int clickedChoiceNum, QuestSceneFlow questSceneFlow)
        {
            // Показать анимацию с портретом
            // вернуться на сл экран 

            AnimationPanelController animationPanelController = questSceneFlow.animationPanelController;
            QuestPanelController questPanelController = questSceneFlow.questPanelController;
            animationPanelController.show("Images/Portrait", () =>
            {
                questPanelController.displayQuestNode("3.1");
            });
        }
    }
}