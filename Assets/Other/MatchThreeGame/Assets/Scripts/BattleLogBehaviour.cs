using UnityEngine;

namespace Other.MatchThreeGame.Assets.Scripts
{
    public class BattleLogBehaviour : MonoBehaviour
    {
        private void Start()
        {
            if (Constants.BattleLogEnabled)
            {
                StateManager stateManager = StateManager.Get();

                stateManager.SubscribeOnPlayerHealthDiff(amount => Debug.Log("Вы: " + amount + "хп"));
                stateManager.SubscribeOnEnemyHealthDiff(amount => Debug.Log("Враг: " + amount + "хп"));
                
                stateManager.SubscribeOnPlayerManaDiff(amount => Debug.Log("Вы: " + amount + "маны"));
                stateManager.SubscribeOnEnemyManaDiff(amount => Debug.Log("Враг: " + amount + "маны"));
                
                stateManager.SubscribeOnIsPlayersTurn(isPlayersTurn => Debug.Log(isPlayersTurn ? "Ваш ход" : "Ход противника"));
            }
        }
    }
}