using System;
using System.Collections;
using DefaultNamespace.Common.UI;
using Other.MatchThreeGame.Assets.Scripts.Model;
using UnityEngine;
using UnityEngine.UI;

namespace Other.MatchThreeGame.Assets.Scripts.UI
{
    public class ToastBehaviour : MonoBehaviour
    {

        public Image background;
        public GameObject gameGoalPanel;
        public GameObject messagePanel;
        public Text messageHeader;
        public float durationOfShowInSeconds = 1f;
        public float flyAwayDuration = 0.4f;
        public float flyAwayYDestination = 1500f;
        

        private StateManager _stateManager;

        public void Init(StateManager stateManager)
        {
            _stateManager = stateManager;
        }

        public void ShowGoal()
        {
            gameObject.SetActive(true);
            gameGoalPanel.SetActive(true);
            StartCoroutine(FlyAwayAfterDelay(gameGoalPanel));
        }

        private IEnumerator FlyAwayAfterDelay(GameObject panel)
        {
            var rectTransform = panel.gameObject.GetComponent<RectTransform>();
            
            yield return new WaitForSeconds(durationOfShowInSeconds);

            var prevBackgroundColor = background.color;
            StartCoroutine(UICoroutines.FadeImageToZeroAlpha(background, flyAwayDuration));
            rectTransform.positionTo(flyAwayDuration, new Vector3(gameObject.transform.position.x, flyAwayYDestination));
            
            yield return new WaitForSeconds(flyAwayDuration);
            rectTransform.position.Set(0, 0, 0);
            background.color = prevBackgroundColor;

            panel.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}