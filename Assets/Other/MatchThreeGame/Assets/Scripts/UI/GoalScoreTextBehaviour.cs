using UnityEngine;
using UnityEngine.UI;

namespace Other.MatchThreeGame.Assets.Scripts.UI
{
    public class GoalScoreTextBehaviour : MonoBehaviour
    {
        private void Start()
        {
            Text text = gameObject.GetComponent<Text>();
            StateManager stateManager = StateManager.Get();

            // stateManager.SubscribeOnLevelInitialized(level => text.text = level.Goals[0].Amount.ToString());
        }
    }
}