using DefaultNamespace;
using DefaultNamespace.model;
using DefaultNamespace.transitions;
using Other.MatchThreeGame.Assets.Scripts.Model;
using UnityEngine.SceneManagement;

namespace QuestScene.Ui.Transitions
{
    public class ThreeInARowTransition : Transition
    {
        public ThreeInARowTransition(string questNodeId, string choiceText, string nextChoiceId) : base(questNodeId, choiceText, nextChoiceId)
        {
        }

        public override void run(QuestNode currentQuestNode, QuestNodeChoice selectedChoice, QuestSceneFlow questSceneFlow)
        {

            if (Prefs.Lifes > 0)
            {
                Prefs.CurrentSceneId = "6.3.1";
                CrossSceneStorage.BackSceneName = "Scenes/QuestScene";
                CrossSceneStorage.IsMinigameInQuest = true;

                SceneManager.LoadScene("Other/MatchThreeGame/Assets/Scenes/mainGame");
            }
            else
            {
                questSceneFlow.dialogBehaviour.Show("Не хватает сердечек");
                var questNode = questSceneFlow.questPanelController.questNodesRepository.findById("6.3");
                questSceneFlow.questPanelController.displayQuestNode(questNode);
            }
        }
    }
}