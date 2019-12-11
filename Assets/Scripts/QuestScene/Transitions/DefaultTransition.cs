using DefaultNamespace.model;

namespace DefaultNamespace.transitions
{
    public class DefaultTransition : Transition
    {
        public DefaultTransition() : base("", -1)
        { }

        public override void run(QuestNode currentQuestNode, int clickedChoiceNum, QuestSceneFlow questSceneFlow)
        {
            QuestPanelController questPanelController = questSceneFlow.questPanelController;

            string nextId = currentQuestNode.choices[clickedChoiceNum].nextId;
            questPanelController.displayQuestNode(nextId);
        }
    }
}