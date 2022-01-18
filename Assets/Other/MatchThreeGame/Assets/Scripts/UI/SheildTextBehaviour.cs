using UnityEngine;

namespace Other.MatchThreeGame.Assets.Scripts.UI
{
    public class SheildTextBehaviour : MonoBehaviour
    {
        private void Start()
        {
            StateManager stateManager = GameObject.Find("State").GetComponent<StateManager>();
        }
    }
}