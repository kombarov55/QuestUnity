using Other.MatchThreeGame.Assets.Scripts.Model;
using UnityEngine;
using UnityEngine.UI;

namespace Other.MatchThreeGame.Assets.Scripts.UI
{
    public class ScoreBehaviour : MonoBehaviour
    {

        private void Awake()
        {
            Slider slider = gameObject.GetComponent<Slider>();
            StateManager stateManager = GameObject.Find("State").GetComponent<StateManager>();
            
            stateManager.SubscribeOnLevelInitialized(level => slider.maxValue = level.Goals[0].Amount);
            stateManager.SubscribeOnScoreChanged(level => slider.value = level.Goals[0].CurrentAmount);
        }
    }
}