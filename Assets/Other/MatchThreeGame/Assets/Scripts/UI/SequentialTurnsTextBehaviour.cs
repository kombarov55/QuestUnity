using DefaultNamespace.Common;
using UnityEngine;
using UnityEngine.UI;

namespace Other.MatchThreeGame.Assets.Scripts.UI
{
    public class SequentialTurnsTextBehaviour : MonoBehaviour
    {
        public bool isForPlayer;
        
        private void Start()
        {
            StateManager stateManager = GameObject.Find("State").GetComponent<StateManager>();
            var text = GetComponent<Text>();

            Observable<int> observable = isForPlayer ? 
                stateManager.SequentialTurnsForPlayer : 
                stateManager.SequentialTurnsForEnemy;
            
            observable.Subscribe(amount => text.text = "(" + amount + ")");
        }
    }
}