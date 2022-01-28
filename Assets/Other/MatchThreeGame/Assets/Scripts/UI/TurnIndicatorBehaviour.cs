using UnityEngine;

namespace Other.MatchThreeGame.Assets.Scripts.UI
{
    public class TurnIndicatorBehaviour : MonoBehaviour
    {

        public bool isForPlayer;
        
        private void Start()
        {
            GameLifecycleObservables gameLifecycleObservables = StateManager.Get().GameLifecycleObservables;
            

            if (isForPlayer)
            {
                gameLifecycleObservables.BeforePlayerTurn.Subscribe(() => gameObject.SetActive(true));
                gameLifecycleObservables.AfterPlayerTurn.Subscribe(() => gameObject.SetActive(false));
            }
            else
            {
                gameLifecycleObservables.BeforeEnemyTurn.Subscribe(() => gameObject.SetActive(true));
                gameLifecycleObservables.AfterEnemyTurn.Subscribe(() => gameObject.SetActive(false));
                gameObject.SetActive(false);
            }
        }
    }
}