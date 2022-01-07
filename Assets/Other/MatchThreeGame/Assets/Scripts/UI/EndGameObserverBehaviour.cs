using System;
using UnityEngine;

namespace Other.MatchThreeGame.Assets.Scripts.UI
{
    public class EndGameObserverBehaviour : MonoBehaviour
    {
        public void Start()
        {
            SceneController sceneController = GameObject.Find("SceneController").GetComponent<SceneController>();
            StateManager stateManager = GameObject.Find("State").GetComponent<StateManager>();
            
            stateManager.SubscribeOnScoreChanged(newValue =>
            {
                if (newValue >= Constants.GoalScore)
                {
                    sceneController.EndGame();
                }
            });
        }
    }
}