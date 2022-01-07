using UnityEngine;
using UnityEngine.UI;

namespace Other.MatchThreeGame.Assets.Scripts.UI
{
    public class ScoreBehaviour : MonoBehaviour
    {

        private void Start()
        {
            Slider slider = gameObject.GetComponent<Slider>();
            StateManager stateManager = GameObject.Find("State").GetComponent<StateManager>();
            
            stateManager.SubscribeOnScoreChanged(value => slider.value = value);
            
            slider.maxValue = Constants.GoalScore;
        }
    }
}