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

        private Observable<Spell> _spellObservable = new Observable<Spell>(null); 
        
        public void Start()
        { 
            _stateManager = GameObject.Find("State").GetComponent<StateManager>();

            ClearGrid();

            _spellObservable.Subscribe(DisplaySpell, true);

            foreach (var spell in _stateManager.PlayerSpellsToCooldownObservable.Keys)
            {
                var go = Instantiate(spellPrefab, scrollViewContent.transform);
                go.GetComponent<SpellBehaviourV2>().Display(spell, _stateManager, () => _spellObservable.Value = spell);
                _instantiatedSpells.Add(go);
            }
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