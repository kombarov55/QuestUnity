using System;
using Other.MatchThreeGame.Assets.Scripts.Model;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Other.MatchThreeGame.Assets.Scripts.UI
{
    public class SpellBehaviourV2 : MonoBehaviour, IPointerClickHandler
    {
        public Image image;
        public Text cooldownText;
        public Color disabledColor;
        
        private Color _enabledColor = new Color(255, 255, 255);
        private Spell _spell;
        private StateManager _stateManager;
        private Action _onClick;
        
        public void Display(StoredSpell storedSpell, StateManager stateManager, Action onClick)
        {
            _stateManager = stateManager;
            _spell = storedSpell.Spell;
            _onClick = onClick;

            image.sprite = Resources.Load<Sprite>(_spell.ImagePath);

            int currentCooldown = storedSpell.GetCurrentCooldown(_stateManager.TurnsLeft);
            
            if (currentCooldown == 0)
            {
                image.color = _enabledColor;
                cooldownText.gameObject.SetActive(false);
            }
            else
            {
                cooldownText.gameObject.SetActive(true);
                image.color = disabledColor;

                cooldownText.text = currentCooldown.ToString();
            }
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            _onClick.Invoke();
        }
    }
}