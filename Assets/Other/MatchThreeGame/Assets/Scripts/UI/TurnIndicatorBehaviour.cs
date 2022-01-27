using UnityEngine;

namespace Other.MatchThreeGame.Assets.Scripts.UI
{
    public class TurnIndicatorBehaviour : MonoBehaviour
    {

        public bool isForPlayer;
        
        private void Start()
        {
            if (isForPlayer)
            {
                GameLifecycleObservables.BeforePlayerTurn.Subscribe(() => gameObject.SetActive(true));
                GameLifecycleObservables.AfterPlayerTurn.Subscribe(() => gameObject.SetActive(false));
            }
            else
            {
                GameLifecycleObservables.BeforeEnemyTurn.Subscribe(() => gameObject.SetActive(true));
                GameLifecycleObservables.AfterEnemyTurn.Subscribe(() => gameObject.SetActive(false));
                gameObject.SetActive(false);
            }
        }
    }
}