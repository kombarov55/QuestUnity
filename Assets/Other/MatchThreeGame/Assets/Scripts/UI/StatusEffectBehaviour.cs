using Other.MatchThreeGame.Assets.Scripts.Model;
using UnityEngine;
using UnityEngine.UI;

namespace Other.MatchThreeGame.Assets.Scripts.UI
{
    public class StatusEffectBehaviour : MonoBehaviour
    {
        public StatusEffect StatusEffect;
        public Text turnsLeftText;
        
        public void Display(StatusEffect statusEffect)
        {
            StatusEffect = statusEffect;
            
            GetComponent<Image>().sprite = Resources.Load<Sprite>(statusEffect.ImagePath);
            turnsLeftText.text = statusEffect.Duration.ToString();
        }

        public void UpdateTurnsLeft(int newAmount)
        {
            turnsLeftText.text = newAmount.ToString();
        }

        public void UpdateTurnsLeft(string text)
        {
            turnsLeftText.text = text;
        }
    }
}