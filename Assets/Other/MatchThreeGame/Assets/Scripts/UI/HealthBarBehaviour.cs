using UnityEngine;
using UnityEngine.UI;

namespace Other.MatchThreeGame.Assets.Scripts.UI
{
    public class HealthBarBehaviour : MonoBehaviour
    {

        public bool isPlayer;
        public GameObject currentHealth;
        
        private void Start()
        {
            StateManager stateManager = GameObject.Find("State").GetComponent<StateManager>();
            Slider slider = gameObject.GetComponent<Slider>();
            Text currentHealthText = currentHealth.GetComponent<Text>();

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
                });
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
                });
            }
        }
    }
}