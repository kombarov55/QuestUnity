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
        
        public void Display(Spell spell, StateManager stateManager, Action onClick)
        {
            _stateManager = stateManager;
            _spell = spell;
            _onClick = onClick;

            image.sprite = Resources.Load<Sprite>(spell.ImagePath);

            _stateManager.PlayerSpellsToCooldownObservable[_spell].Subscribe(currentCooldown =>
            {
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
            }, true);
            
            _stateManager.SubscribeOnIsPlayersTurn(isPlayersTurn =>
            {
                if (isPlayersTurn)
                {
                    int currentCooldown = _stateManager.PlayerSpellsToCooldownObservable[_spell].Value;

                    if (currentCooldown > 0)
                    {
                        _stateManager.PlayerSpellsToCooldownObservable[_spell].Value = currentCooldown - 1;
                    }
                }
            });
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            _onClick.Invoke();
        }
    }
}