﻿using System;
using System.Collections.Generic;
using DefaultNamespace.Common;
using Other.MatchThreeGame.Assets.Scripts.Model;
using UnityEngine;
using UnityEngine.UI;

namespace Other.MatchThreeGame.Assets.Scripts.UI
{
    public class InventoryPanelBehaviour : MonoBehaviour
    {
        public GameObject itemPrefab;
        public GameObject container;
        public Text itemNameText;
        public Text itemDescriptionText;
        public Image itemImage;
        public AudioButton audioButton;

        private List<GameObject> _instantiatedItems = new List<GameObject>();
        private StateManager _stateManager;

        private Observable<int> _amountObservable;
        private string _subscriberGuidOfItemAmountChangeOnButton;

        private Button _button;

        private void Start()
        {
            _stateManager = StateManager.Get();
            _button = audioButton.gameObject.GetComponent<Button>();
            
            _stateManager.IsAnyPanelDisplayedOnUI = true;
            
            Clear();
            ClearDisplayOfItem();            
            
            foreach (var inventoryItem in _stateManager.InventoryItemsOfPlayer)
            {
                var go = Instantiate(itemPrefab, container.transform);
                go.GetComponent<ItemBehaviour>().Display(inventoryItem, item => DisplaySelectedItem(item));
                _instantiatedItems.Add(go);
            }
        }

        private void DisplaySelectedItem(StoredItem storedItem)
        {
            if (storedItem == null)
            {
                ClearDisplayOfItem();
            }
            else
            {
                itemNameText.text = storedItem.ItemRepository.Name;
                itemDescriptionText.text = storedItem.ItemRepository.Description;
                itemImage.gameObject.SetActive(true);
                itemImage.sprite = Resources.Load<Sprite>(storedItem.ItemRepository.ImagePath);

                audioButton.gameObject.SetActive(true);
                audioButton.OnClick = () =>
                {
                    if (_button.interactable)
                    {
                        var itemTemplate = storedItem.ItemRepository;
                        itemTemplate.ActionsOfSelfWhenUsed.ForEach(v => v.Cast(_stateManager, true));
                        itemTemplate.ActionsOfEnemyWhenUsed.ForEach(v => v.Cast(_stateManager, false));
                        itemTemplate.StatusEffectsOnSelfWhenUsed.ForEach(v =>
                            _stateManager.AddStatusEffectOnPlayer(new RunningStatusEffect(v)));
                        itemTemplate.StatusEffectsOnEnemyWhenUsed.ForEach(v =>
                            _stateManager.AddStatusEffectOnEnemy(new RunningStatusEffect(v)));

                        _stateManager.SoundManager.PlaySound(itemTemplate.SoundOnUsePath);
                        storedItem.Amount.Value -= 1;

                        ClearDisplayOfItem();
                        gameObject.SetActive(false);
                    }
                };

                if (_amountObservable != null)
                {
                    _amountObservable.Unsubscribe(_subscriberGuidOfItemAmountChangeOnButton);
                }

                _amountObservable = storedItem.Amount;
            
                _subscriberGuidOfItemAmountChangeOnButton = _amountObservable.Subscribe(amount =>
                {
                    _button.interactable = amount != 0;
                }, true);                
            }
        }

        private void UseItem()
        {
            
        }

        public void OnEnable()
        {
            GameObject.Find("State").GetComponent<StateManager>().IsAnyPanelDisplayedOnUI = true;
        }

        public void OnDisable()
        {
            GameObject.Find("State").GetComponent<StateManager>().IsAnyPanelDisplayedOnUI = false;
        }

        private void Clear()
        {
            container.transform.DetachChildren();
            foreach (var go in _instantiatedItems)
            {
                Destroy(go);
            }
        }

        private void ClearDisplayOfItem()
        {
            itemNameText.text = "";
            itemDescriptionText.text = "";
            itemImage.gameObject.SetActive(false);
            audioButton.gameObject.SetActive(false);
        }
    }
}