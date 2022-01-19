using DefaultNamespace.Common;
using UnityEngine;
using UnityEngine.UI;

namespace Other.MatchThreeGame.Assets.Scripts.UI
{
    public class SheildTextBehaviour : MonoBehaviour
    {
        public bool isForPlayer;
        
        private void Start()
        {
            StateManager stateManager = GameObject.Find("State").GetComponent<StateManager>();
            var text = GetComponent<Text>();
            text.text = "";

            Observable<int> observable =
                isForPlayer ? stateManager.PlayerDamageBlocked : stateManager.EnemyDamageBlocked;

            observable.Subscribe(amount =>
            {
                text.text = amount != 0 ? amount.ToString() : "";
            });
        }
    }
}