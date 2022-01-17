using UnityEngine;

namespace Other.MatchThreeGame.Assets.Scripts
{
    public class CollapseObserverBehaviour : MonoBehaviour
    {
        private void Start()
        {
            StateManager stateManager = GameObject.Find("State").GetComponent<StateManager>();
            
            stateManager.SubscribeOnCollapse(match =>
            {
                if (stateManager.IsPlayersTurn)
                {
                    stateManager.EnemyHealthLeft -= 1;
                }
                else
                {
                    stateManager.PlayerHealthLeft -= 1;                    
                }
            });
        }
    }
}