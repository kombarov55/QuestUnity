using Other.MatchThreeGame.Assets.Scripts.Model;
using Other.MatchThreeGame.Assets.Scripts.Service;
using UnityEngine;

namespace Other.MatchThreeGame.Assets.Scripts.UI
{
    public class GameStatusObserverBehaviour : MonoBehaviour
    {
        public void Start()
        {
            SceneController sceneController = GameObject.Find("SceneController").GetComponent<SceneController>();
            StateManager stateManager = GameObject.Find("State").GetComponent<StateManager>();
            GameplayService gameplayService = new GameplayService();

            stateManager.SubscribeOnLevelInitialized(level =>
            {
                sceneController.ShowGoals(level);
            });
            
            stateManager.SubscribeOnScoreChanged(level =>
            {
                GameStatus currentGameStatus = gameplayService.CalculateCurrentGameStatus(level);

                if (currentGameStatus == GameStatus.VICTORY)
                {
                    sceneController.ShowVictory();
                } else if (currentGameStatus == GameStatus.FAILURE)
                {
                    sceneController.ShowFailure();
                }
            });
        }
    }
}