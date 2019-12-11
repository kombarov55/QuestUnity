using DefaultNamespace.model;

namespace DefaultNamespace.transitions
{
    public class DefaultTransition : Transition
    {
        public DefaultTransition() : base("", -1)
        { }

        public override void run(QuestNode currentQuestNode, int clickedChoiceNum, QuestSceneController questSceneController)
        {
            string nextId = currentQuestNode.choices[clickedChoiceNum].nextId;
            questSceneController.displayQuestNode(nextId);
        }
    }
}