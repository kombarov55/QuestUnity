using System;
using System.Collections;
using DefaultNamespace.Common.UI;
using Other.MatchThreeGame.Assets.Scripts.Model;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Other.MatchThreeGame.Assets.Scripts.UI
{
    public class ToastBehaviour : MonoBehaviour
    {

        public Image background;
        public GameObject gameGoalPanel;
        public Text enemyNameText;
        public Text playerHealthText;
        public Text playerManaText;
        public Text enemyHealthText;
        public Text enemyManaText;

        public GameObject messagePanel;
        public Text messageHeader;
        public int durationOfShowInSeconds = 1;
        public float flyAwayDuration = 0.4f;
        public float flyAwayYDestination = 1500f;
        

        private StateManager _stateManager;

        public void Init(StateManager stateManager)
        {
            _stateManager = stateManager;
        }

        public void ShowGoal(Level level)
        {
            gameObject.SetActive(true);
            gameGoalPanel.SetActive(true);
            _stateManager.IsAnyPanelDisplayedOnUI = true;
            
            
            playerHealthText.text = level.PlayerHealth.ToString();
            playerManaText.text = level.PlayerMana.ToString();
            enemyNameText.text = level.EnemyName;
            enemyHealthText.text = level.EnemyHealth.ToString();
            enemyManaText.text = level.EnemyMana.ToString();
            
            StartCoroutine(FlyAwayAfterDelay(gameGoalPanel, true));
        }

        public void ShowVictory()
        {
            gameObject.SetActive(true);
            messagePanel.SetActive(true);
            messageHeader.text = "Победа!";
            StartCoroutine(FlyAwayAfterDelay(messagePanel, false, () => SceneManager.LoadScene("MainMenu")));
        }
        
        public void ShowFailure()
        {
            gameObject.SetActive(true);
            messagePanel.SetActive(true);
            messageHeader.text = "Поражение";
            StartCoroutine(FlyAwayAfterDelay(messagePanel, false));
        }

        private IEnumerator FlyAwayAfterDelay(GameObject panel, bool fadeBackground, Action then = null)
        {
            var rectTransform = panel.gameObject.GetComponent<RectTransform>();
            
            yield return new WaitForSeconds(durationOfShowInSeconds);
            
            _stateManager.IsAnyPanelDisplayedOnUI = false;

            rectTransform.positionTo(flyAwayDuration, new Vector3(gameObject.transform.position.x, flyAwayYDestination));
            var prevBackgroundColor = background.color;
            if (fadeBackground)
            {
                StartCoroutine(UICoroutines.FadeImageToZeroAlpha(background, flyAwayDuration));                
            }
            else
            {
                StartCoroutine(UICoroutines.FadeImageToFullAlpha(background, flyAwayDuration));
            }
            
            yield return new WaitForSeconds(flyAwayDuration);

            if (fadeBackground)
            {
                rectTransform.position.Set(0, 0, 0);
                background.color = prevBackgroundColor;

                panel.SetActive(false);
                gameObject.SetActive(false);
            }

            if (then != null)
            {
                then.Invoke();
            }
        }
    }
}