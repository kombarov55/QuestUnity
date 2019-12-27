using DefaultNamespace.model;

namespace DefaultNamespace.transitions
{
    public class DefaultTransition : Transition
    {
        public DefaultTransition() : base("", "", "")
        { }

        public override void run(QuestNode currentQuestNode, QuestNodeChoice selectedChoice, QuestSceneFlow questSceneFlow)
        {
            QuestPanelController questPanelController = questSceneFlow.questPanelController;

            string nextId = selectedChoice.nextId;
            questPanelController.displayQuestNode(nextId);
        }
    }
}