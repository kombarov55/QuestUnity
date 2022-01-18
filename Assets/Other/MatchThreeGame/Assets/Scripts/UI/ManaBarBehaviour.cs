using UnityEngine;
using UnityEngine.UI;

namespace Other.MatchThreeGame.Assets.Scripts.UI
{
    public class ManaBarBehaviour : MonoBehaviour
    {

        public bool isPlayer;
        public GameObject currentMana;
        
        private void Start()
        {
            StateManager stateManager = GameObject.Find("State").GetComponent<StateManager>();
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
            }
            else
            {
                stateManager.SubscribeOnLevelInitialized(level => slider.maxValue = level.EnemyMana);
                stateManager.SubscribeOnEnemyManaChanged(mana =>
                {
                    currentManaText.text = mana.ToString();
                    slider.value = mana;
                });
            }
        }
    }
}