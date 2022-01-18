﻿using Other.MatchThreeGame.Assets.Scripts.Model;
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
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (_stateManager.PlayerManaLeft >= _spell.ManaCost)
            {
                Cast();
            }
        }


        public void Cast()
        {
            _spellBookPanel.SetActive(false);
            _stateManager.PlayerManaLeft -= _spell.ManaCost;
            foreach (var spellAction in _spell.SpellActions)
            {
                spellAction.Invoke(_stateManager);
            }
        }
    }
}