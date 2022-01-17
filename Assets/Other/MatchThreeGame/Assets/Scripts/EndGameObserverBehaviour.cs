using DefaultNamespace;
using Other.MatchThreeGame.Assets.Scripts.Model;
using Other.MatchThreeGame.Assets.Scripts.Service;
using UnityEngine;

namespace Other.MatchThreeGame.Assets.Scripts.UI
{
    public class EndGameObserverBehaviour : MonoBehaviour
    {
        public void Start()
        {
            SceneController sceneController = GameObject.Find("SceneController").GetComponent<SceneController>();
            StateManager stateManager = GameObject.Find("State").GetComponent<StateManager>();

            stateManager.SubscribeOnLevelInitialized(level =>
            {
                sceneController.ShowGoals(level);
            });
            
        }
    }
}