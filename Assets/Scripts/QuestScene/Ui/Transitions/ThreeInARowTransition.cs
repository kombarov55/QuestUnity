using DefaultNamespace;
using DefaultNamespace.model;
using DefaultNamespace.transitions;
using UnityEngine;

namespace QuestScene.Ui.Transitions
{
    public class ThreeInARowTransition : Transition
    {
        public ThreeInARowTransition(string questNodeId, string choiceText, string choiceNextId) : base(questNodeId, choiceText, choiceNextId)
        {
        }

        public override void run(QuestNode currentQuestNode, QuestNodeChoice selectedChoice, QuestSceneFlow questSceneFlow)
        {
            Debug.Log("ПРИВЕТ!");
            questSceneFlow.questPanelController.displayQuestNode("6.3");
        }
    }
}