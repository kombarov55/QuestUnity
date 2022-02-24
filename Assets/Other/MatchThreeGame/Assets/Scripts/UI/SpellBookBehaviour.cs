using System.Collections.Generic;
using DefaultNamespace.Common;
using Other.MatchThreeGame.Assets.Scripts.Model;
using UnityEngine;
using UnityEngine.UI;

namespace Other.MatchThreeGame.Assets.Scripts.UI
{
    public class SpellBookBehaviour : MonoBehaviour
    {
        public GameObject scrollViewContent;
        public GameObject spellPrefab;
        public Text spellNameText;
        public Text spellDescriptionText;
        public Image spellImage;
        public Image manaImage;
        public Text manacostText;
        public Text cooldownText;
        public AudioButton audioButton;

        private Button _button;
        private List<GameObject> _instantiatedSpells = new List<GameObject>();
        private StateManager _stateManager;
        private SoundManager _soundManager;

        private Observable<StoredSpell> _selectedSpell = new Observable<StoredSpell>(null);

        public void OnEnable()
        {
            GameObject.Find("State").GetComponent<StateManager>().IsAnyPanelDisplayedOnUI = true;
            _stateManager = StateManager.Get();
            _soundManager = _stateManager.SoundManager;
            _button = audioButton.GetComponent<Button>();

            ClearGrid();
            
            foreach (StoredSpell storedSpell in _stateManager.StoredSpells)
            {
                var go = Instantiate(spellPrefab, scrollViewContent.transform);
                go.GetComponent<SpellBehaviourV2>().Display(storedSpell, _stateManager, () => _selectedSpell.Value = storedSpell);
                _instantiatedSpells.Add(go);
            }

            _selectedSpell.Subscribe(storedSpell =>
            {
                DisplaySpell(storedSpell);

                if (storedSpell != null)
                {
                    bool playerHasEnoughMana = _stateManager.PlayerManaLeft >= storedSpell.Spell.ManaCost;
                    bool spellIsNotOnCooldown = !storedSpell.IsOnCooldown(_stateManager.TurnsLeft);
                    bool spellIsNotSilented = _stateManager.SilentedSpellsForPlayer.Find(v => v.Id == storedSpell.Spell.Id) == null;
                
                
                    _button.interactable = playerHasEnoughMana && spellIsNotOnCooldown && spellIsNotSilented;
                }
            }, true);
            
            audioButton.OnClick = () =>
            {
                StoredSpell storedSpell = _selectedSpell.Value;
            
                if (storedSpell == null)
                {
                    return;
                }
            
                Cast(storedSpell);
            };
        }

        public void OnDisable()
        {
            GameObject.Find("State").GetComponent<StateManager>().IsAnyPanelDisplayedOnUI = false;
            ClearGrid();
        }

        private void DisplaySpell(StoredSpell storedSpell)
        {
            if (storedSpell == null)
            {
                spellNameText.text = "";
                spellDescriptionText.text = "";
                spellImage.gameObject.SetActive(false);
                audioButton.gameObject.SetActive(false);
                manaImage.gameObject.SetActive(false);
                manacostText.text = "";
                cooldownText.text = "";
            }
            else
            {
                spellNameText.text = storedSpell.Spell.Name;
                spellDescriptionText.text = storedSpell.Spell.Description;
                spellImage.gameObject.SetActive(true);
                audioButton.gameObject.SetActive(true);
                manaImage.gameObject.SetActive(true);
                spellImage.sprite = Resources.Load<Sprite>(storedSpell.Spell.ImagePath);
                manacostText.text = "x" + storedSpell.Spell.ManaCost;
                cooldownText.text = "Перезарядка " + storedSpell.Spell.Cooldown + " ходов";
            }
        }
        
        private void Cast(StoredSpell storedSpell)
        {
            gameObject.SetActive(false);
            _selectedSpell.Value = null;
            _stateManager.CastsLeftForPlayer.Value -= 1;
            storedSpell.TurnWhenUsed = _stateManager.TurnsLeft;

            _stateManager.PlayerManaLeft -= storedSpell.Spell.ManaCost;
            _stateManager.OnPlayerManaChanged(-storedSpell.Spell.ManaCost);
            
            PlaySpellSound(storedSpell.Spell);

            foreach (var spellAction in storedSpell.Spell.SpellActionsToSelf)
            {
                spellAction.Cast(_stateManager, true);
            }
            
            foreach (var spellAction in storedSpell.Spell.SpellActionsToEnemy)
            {
                spellAction.Cast(_stateManager, false);
            }
            
            foreach (var statusEffect in storedSpell.Spell.StatusEffectsOnSelf)
            {
                _stateManager.AddStatusEffectOnPlayer(statusEffect);
            }

            foreach (var statusEffect in storedSpell.Spell.StatusEffectsOnEnemy)
            {
                _stateManager.AddStatusEffectOnEnemy(statusEffect);
            }

            if (storedSpell.Spell.SpellActionsToSelf.Count != 0 || storedSpell.Spell.StatusEffectsOnSelf.Count != 0)
            {
                _stateManager.MagicEffectThrownOnPlayer.Value = storedSpell.Spell.SpellType;
            }
            
            if (storedSpell.Spell.SpellActionsToEnemy.Count != 0 || storedSpell.Spell.StatusEffectsOnEnemy.Count != 0)
            {
                _stateManager.MagicEffectThrownOnEnemy.Value = storedSpell.Spell.SpellType;
            }
        }
        
        private void PlaySpellSound(Spell spell) 
        {
            switch (spell.SpellType)
            {
                case SpellType.Damage: 
                    _soundManager.PlayDamageSpellSound();
                    break;
                case SpellType.Heal:
                    _soundManager.PlayHealingSpellSound();
                    break;
                case SpellType.Buff: 
                    _soundManager.PlayBuffSpellSound();
                    break;
                case SpellType.Debuff: 
                    _soundManager.PlayDebuffSpellSound();
                    break;
            }
        }


        private void ClearGrid()
        {
            scrollViewContent.transform.DetachChildren();
            foreach (var go in _instantiatedSpells)
            {
                Destroy(go);
            }
        }
    }
}