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
            StateManager stateManager = StateManager.Get();
            
            stateManager.SubscribeOnScoreChanged(level => slider.value = stateManager.Score);
        }
    }
}