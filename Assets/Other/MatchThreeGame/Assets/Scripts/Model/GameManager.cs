using UnityEngine;

namespace Other.MatchThreeGame.Assets.Scripts.Model
{
    public class GameManager : MonoBehaviour
    {
        private void Start()
        {
            StateManager stateManager = GameObject.Find("State").GetComponent<StateManager>();

            // GameLifecycleObservables.BeforeSuccessfulShapeSwapByPlayer.Subscribe(() =>
            // {
            //     stateManager.SequentialTurnsForPlayer.Value -= 1;
            // });
        }
    }
}