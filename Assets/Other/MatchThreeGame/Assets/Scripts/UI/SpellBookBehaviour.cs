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

        private Observable<Spell> _spellObservable = new Observable<Spell>(null);

        public void Start()
        { 
            _stateManager = GameObject.Find("State").GetComponent<StateManager>();
            _soundManager = _stateManager.SoundManager;

            ClearGrid();

            _spellObservable.Subscribe(spell =>
            {
                DisplaySpell(spell);

                if (spell != null)
                {
                
                    bool playerHasEnoughMana = _stateManager.PlayerManaLeft >= spell.ManaCost;
                    bool spellIsNotOnCooldown = _stateManager.PlayerSpellsToCooldownObservable[spell].Value == 0;
                    bool spellIsNotSilented = _stateManager.SilentedSpellsForPlayer.Find(v => v.Id == spell.Id) == null;
                
                
                    _button.interactable = playerHasEnoughMana && spellIsNotOnCooldown && spellIsNotSilented;
                }
            }, true);

            foreach (var spell in _stateManager.PlayerSpellsToCooldownObservable.Keys)
            {
                var go = Instantiate(spellPrefab, scrollViewContent.transform);
                go.GetComponent<SpellBehaviourV2>().Display(spell, _stateManager, () => _spellObservable.Value = spell);
                _instantiatedSpells.Add(go);
            }

            audioButton.OnClick = () =>
            {
                Spell spell = _spellObservable.Value;
            
                if (spell == null)
                {
                    return;
                }
            
                Cast(spell);
            };
        }

        public void OnEnable()
        {
            GameObject.Find("State").GetComponent<StateManager>().IsAnyPanelDisplayedOnUI = true;
        }

        public void OnDisable()
        {
            GameObject.Find("State").GetComponent<StateManager>().IsAnyPanelDisplayedOnUI = false;
        }

        private void DisplaySpell(Spell spell)
        {
            if (spell == null)
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
                spellNameText.text = spell.Name;
                spellDescriptionText.text = spell.Description;
                spellImage.gameObject.SetActive(true);
                audioButton.gameObject.SetActive(true);
                manaImage.gameObject.SetActive(true);
                spellImage.sprite = Resources.Load<Sprite>(spell.ImagePath);
                manacostText.text = "x" + spell.ManaCost;
                cooldownText.text = "Перезарядка: " + spell.Cooldown + " ходов";
            }
        }
        
        private void Cast(Spell spell)
        {
            gameObject.SetActive(false);
            _stateManager.CastsLeftForPlayer.Value -= 1;
            _stateManager.PlayerSpellsToCooldownObservable[spell].Value = spell.Cooldown;
            
            _stateManager.PlayerManaLeft -= spell.ManaCost;
            _stateManager.OnPlayerManaChanged(-spell.ManaCost);
            
            PlaySpellSound(spell);

            foreach (var spellAction in spell.SpellActionsToSelf)
            {
                spellAction.Cast(_stateManager, true);
            }
            
            foreach (var spellAction in spell.SpellActionsToEnemy)
            {
                spellAction.Cast(_stateManager, false);
            }
            
            foreach (var statusEffect in spell.StatusEffectsOnSelf)
            {
                _stateManager.AddStatusEffectOnPlayer(statusEffect);
            }

            foreach (var statusEffect in spell.StatusEffectsOnEnemy)
            {
                _stateManager.AddStatusEffectOnEnemy(statusEffect);
            }

            if (spell.SpellActionsToSelf.Count != 0 || spell.StatusEffectsOnSelf.Count != 0)
            {
                _stateManager.MagicEffectThrownOnPlayer.Value = spell.SpellType;
            }
            
            if (spell.SpellActionsToEnemy.Count != 0 || spell.StatusEffectsOnEnemy.Count != 0)
            {
                _stateManager.MagicEffectThrownOnEnemy.Value = spell.SpellType;
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