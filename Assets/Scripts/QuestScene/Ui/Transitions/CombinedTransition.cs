using DefaultNamespace;
using DefaultNamespace.model;
using DefaultNamespace.transitions;

namespace QuestScene.Ui.Transitions
{
    public class CombinedTransition : Transition
    {
        private Transition[] transitions;
        
        public CombinedTransition(string questNodeId, string choiceText, string choiceNextId, params Transition[] transitions) : base(questNodeId, choiceText, choiceNextId)
        {
            this.transitions = transitions;
        }

        public override void run(QuestNode currentQuestNode, QuestNodeChoice selectedChoice, QuestSceneFlow questSceneFlow)
        {
            foreach (var transition in transitions)
            {
                transition.run(currentQuestNode, selectedChoice, questSceneFlow);
            }
        }
    }
}