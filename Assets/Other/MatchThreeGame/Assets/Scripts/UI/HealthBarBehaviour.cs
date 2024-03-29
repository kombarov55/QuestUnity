﻿using UnityEngine;
using UnityEngine.UI;

namespace Other.MatchThreeGame.Assets.Scripts.UI
{
    public class HealthBarBehaviour : MonoBehaviour
    {

        public bool isPlayer;
        public GameObject currentHealth;
        public bool showHealthDelta = false;
        public GameObject healthDiffFadingTextPrefab;
        public GameObject fadingTextInitialPosition;
        public GameObject fadingTextTargetPosition;
        public float fadingTextDurationInSeconds = 1f;

        private BounceBehaviour _currentHealthBounceBehaviour;
        
        private void Start()
        {
            StateManager stateManager = StateManager.Get();
            Slider slider = gameObject.GetComponent<Slider>();
            Text currentHealthText = currentHealth.GetComponent<Text>();
            _currentHealthBounceBehaviour = currentHealth.GetComponent<BounceBehaviour>();

            if (isPlayer)
            {
                stateManager.SubscribeOnLevelInitialized(level =>
                {
                    slider.maxValue = level.PlayerHealth;
                });
                
                stateManager.SubscribeOnPlayerHealthChanged(value =>
                {
                    slider.value = value;
                    currentHealthText.text = value.ToString();
                    _currentHealthBounceBehaviour.Run();
                });

                if (showHealthDelta)
                {
                    stateManager.SubscribeOnPlayerHealthDiff(diff =>
                    {
                        var go = Instantiate(healthDiffFadingTextPrefab, gameObject.transform);
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
                stateManager.SubscribeOnLevelInitialized(level =>
                {
                    slider.maxValue = level.EnemyHealth;
                });
                stateManager.SubscribeOnEnemyHealthChanged(value =>
                {
                    slider.value = value;
                    currentHealthText.text = value.ToString();
                    _currentHealthBounceBehaviour.Run();
                });
                
                if (showHealthDelta)
                {
                    stateManager.SubscribeOnEnemyHealthDiff(diff =>
                    {
                        var go = Instantiate(healthDiffFadingTextPrefab, gameObject.transform);
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