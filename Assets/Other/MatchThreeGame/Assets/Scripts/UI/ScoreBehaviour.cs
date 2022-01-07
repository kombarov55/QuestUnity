using UnityEngine;
using UnityEngine.UI;

namespace Other.MatchThreeGame.Assets.Scripts.UI
{
    public class ScoreBehaviour : MonoBehaviour
    {

        private Slider _slider;
        private StateManager _stateManager;
        
        private void Start()
        {
            _slider = gameObject.GetComponent<Slider>();
            _stateManager = GameObject.Find("State").GetComponent<StateManager>();
            
            _stateManager.SubscribeOnValueChanged((value) =>
            {
                _slider.value = value;
            });
        }
    }
}