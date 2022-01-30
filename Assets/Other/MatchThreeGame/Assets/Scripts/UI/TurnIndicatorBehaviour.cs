using UnityEngine;

namespace Other.MatchThreeGame.Assets.Scripts.UI
{
    public class TurnIndicatorBehaviour : MonoBehaviour
    {

        public bool isForPlayer;
        
        private void Start()
        {
            StateManager stateManager = StateManager.Get();


            if (isForPlayer)
            {
                stateManager.SequentialTurnsForPlayer.Subscribe(v => gameObject.SetActive(v != 0), true);
            }
            else
            {
                stateManager.SequentialTurnsForEnemy.Subscribe(v => gameObject.SetActive(v != 0), true);
            }
        }
    }
}