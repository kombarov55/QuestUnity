using Other.MatchThreeGame.Assets.Scripts.Model;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Other.MatchThreeGame.Assets.Scripts.UI
{
    public class SpellBehaviour : MonoBehaviour, IPointerClickHandler
    {

        public Image image;
        public Text title;
        public Text description;
        public Text manaCostText;
        public Text cooldownText;
        public Text currentCooldownText;

        private Spell _spell;
        private StateManager _stateManager;
        private GameObject _spellBookPanel;
        
        public void Display(Spell spell, StateManager stateManager, GameObject spellBookPanel)
        {
            _spell = spell;
            _stateManager = stateManager;
            _spellBookPanel = spellBookPanel;
            
            title.text = spell.Name;
            description.text = spell.Description;
            image.sprite = Resources.Load<Sprite>(spell.ImagePath);
            manaCostText.text = spell.ManaCost + " маны";
            cooldownText.text = "Перезарядка: " + _spell.Cooldown + " ходов";
            currentCooldownText.text = "";
            
            stateManager.SpellToCooldownObservable[_spell].Subscribe(currentCooldown =>
            {
                if (currentCooldown > 0)
                {
                    currentCooldownText.text = "Перезарядка: осталось " + currentCooldown + " ходов";                    
                }
                else
                {
                    currentCooldownText.text = "";
                }
            });
            
            stateManager.SubscribeOnIsPlayersTurn(isPlayersTurn =>
            {
                if (isPlayersTurn)
                {
                    int currentCooldown = stateManager.SpellToCooldownObservable[_spell].Value;

                    if (currentCooldown > 0)
                    {
                        stateManager.SpellToCooldownObservable[_spell].Value = currentCooldown - 1;
                    }
                }
            });
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (_stateManager.PlayerManaLeft >= _spell.ManaCost && _stateManager.SpellToCooldownObservable[_spell].Value == 0)
            {
                Cast();
            }
        }


        public void Cast()
        {
            _spellBookPanel.SetActive(false);
            _stateManager.CastsLeftForPlayer.Value -= 1;
            _stateManager.SpellToCooldownObservable[_spell].Value = _spell.Cooldown;
            
            _stateManager.PlayerManaLeft -= _spell.ManaCost;
            _stateManager.OnPlayerManaChanged(-_spell.ManaCost);

            foreach (var spellAction in _spell.SpellActionsToSelf)
            {
                spellAction.Cast(_stateManager, true);
            }
            
            foreach (var spellAction in _spell.SpellActionsToEnemy)
            {
                spellAction.Cast(_stateManager, false);
            }
            
            foreach (var statusEffect in _spell.StatusEffectsOnSelf)
            {
                _stateManager.AddStatusEffectOnPlayer(statusEffect);
            }

            foreach (var statusEffect in _spell.StatusEffectsOnEnemy)
            {
                _stateManager.AddStatusEffectOnEnemy(statusEffect);
            }
        }
    }
}