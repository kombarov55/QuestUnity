using UnityEngine;
using UnityEngine.UI;

namespace Other.MatchThreeGame.Assets.Scripts.UI
{
    public class GoalScoreTextBehaviour : MonoBehaviour
    {
        private void Start()
        {
            Text text = gameObject.GetComponent<Text>();
            text.text = Constants.GoalScore.ToString();
        }
    }
}