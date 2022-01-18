using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Other.MatchThreeGame.Assets.Scripts.UI
{
    public class CoinCountTextBehaviour : MonoBehaviour
    {

        public float popupDuration = 0.25f;
        public float popupAmount = 1.5f;

        private Text text;
        
        private void Start()
        {
            StateManager stateManager = GameObject.Find("State").GetComponent<StateManager>();
            text = GetComponent<Text>();
            
            stateManager.SubscribeOnCoinCountChanged(amount =>
            {
                text.text = "x " + amount;
                StartCoroutine(Popup());
            });
        }

        private IEnumerator Popup()
        {
            text.transform.scaleTo(popupDuration, popupAmount);
            yield return new WaitForSeconds(popupDuration);
            text.transform.scaleTo(popupDuration, 1f);
        }
    }
}