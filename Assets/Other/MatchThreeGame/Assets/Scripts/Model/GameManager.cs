using UnityEngine;

namespace Other.MatchThreeGame.Assets.Scripts.Model
{
    public class GameManager : MonoBehaviour
    {
        private void Start()
        {
            StateManager stateManager = StateManager.Get();

            // GameLifecycleObservables.BeforeSuccessfulShapeSwapByPlayer.Subscribe(() =>
            // {
            //     stateManager.SequentialTurnsForPlayer.Value -= 1;
            // });
        }
    }
}