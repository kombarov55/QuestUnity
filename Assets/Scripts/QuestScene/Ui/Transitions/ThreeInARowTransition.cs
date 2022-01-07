using DefaultNamespace;
using DefaultNamespace.model;
using DefaultNamespace.transitions;
using UnityEngine.SceneManagement;

namespace QuestScene.Ui.Transitions
{
    public class ThreeInARowTransition : Transition
    {
        public ThreeInARowTransition(string questNodeId, string choiceText, string choiceNextId) : base(questNodeId, choiceText, choiceNextId)
        {
        }

        public override void run(QuestNode currentQuestNode, QuestNodeChoice selectedChoice, QuestSceneFlow questSceneFlow)
        {
            questSceneFlow.cachedUserData.CurrentSceneId = "6.3.1";
            CrossSceneStorage.BackSceneName = "Scenes/QuestScene";

            SceneManager.LoadScene("Other/MatchThreeGame/Assets/Scenes/mainGame");
        }
    }
}