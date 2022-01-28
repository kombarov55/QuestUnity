using UnityEngine;
using UnityEngine.UI;

namespace Other.MatchThreeGame.Assets.Scripts.UI
{
    public class ManaBarBehaviour : MonoBehaviour
    {

        public bool isPlayer;
        public GameObject currentMana;
        public bool showManaDiff;
        public GameObject manaDiffFadingTextPrefab;
        public GameObject fadingTextInitialPosition;
        public GameObject fadingTextTargetPosition;
        public int fadingTextDurationInSeconds = 1;
        
        private void Start()
        {
            StateManager stateManager = StateManager.Get();
            Slider slider = gameObject.GetComponent<Slider>();
            Text currentManaText = currentMana.GetComponent<Text>();

            if (isPlayer)
            {
                stateManager.SubscribeOnLevelInitialized(level => slider.maxValue = level.PlayerMana);
                stateManager.SubscribeOnPlayerManaChanged(mana =>
                {
                    currentManaText.text = mana.ToString();
                    slider.value = mana;
                });

                if (showManaDiff)
                {
                    stateManager.SubscribeOnPlayerManaDiff(diff =>
                    {                        var go = Instantiate(manaDiffFadingTextPrefab, gameObject.transform);
                        go.transform.position = fadingTextInitialPosition.transform.position;
                        
                        var fadingTextBehaviour = go.GetComponent<FadingTextBehaviour>();
                        fadingTextBehaviour.Display(
                            diff,
                            fadingTextDurationInSeconds,
                            fadingTextTargetPosition.transform.position
                        );
                    });
                }
            }
            else
            {
                stateManager.SubscribeOnLevelInitialized(level => slider.maxValue = level.EnemyMana);
                stateManager.SubscribeOnEnemyManaChanged(mana =>
                {
                    currentManaText.text = mana.ToString();
                    slider.value = mana;
                });
                
                if (showManaDiff)
                {
                    stateManager.SubscribeOnEnemyManaDiff(diff =>
                    {                        var go = Instantiate(manaDiffFadingTextPrefab, gameObject.transform);
                        go.transform.position = fadingTextInitialPosition.transform.position;
                        
                        var fadingTextBehaviour = go.GetComponent<FadingTextBehaviour>();
                        fadingTextBehaviour.Display(
                            diff,
                            fadingTextDurationInSeconds,
                            fadingTextTargetPosition.transform.position
                        );
                    });
                }
            }
        }
    }
}