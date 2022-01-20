using System;
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
        public AudioButton useButton;

        private List<GameObject> _instantiatedItems = new List<GameObject>();
        private StateManager _stateManager;

        private Observable<int> _amountObservable;
        private string _subscriberGuidOfItemAmountChangeOnButton;

        private void Start()
        {
            _stateManager = GameObject.Find("State").GetComponent<StateManager>();
            _stateManager.IsAnyPanelDisplayedOnUI = true;
            
            Clear();
            
            foreach (var inventoryItem in _stateManager.InventoryItemsOfPlayer)
            {
                var go = Instantiate(itemPrefab, container.transform);
                go.GetComponent<ItemBehaviour>().Display(inventoryItem, item => DisplaySelectedItem(item));
                _instantiatedItems.Add(go);
            }
        }

        private void DisplaySelectedItem(InventoryItem inventoryItem)
        {
            itemNameText.text = inventoryItem.ItemTemplate.Name;
            itemDescriptionText.text = inventoryItem.ItemTemplate.Description;
            itemImage.sprite = Resources.Load<Sprite>(inventoryItem.ItemTemplate.ImagePath);

            useButton.gameObject.SetActive(true);
            useButton.OnClick = () =>
            {
                if (useButton.enabled)
                {
                    var itemTemplate = inventoryItem.ItemTemplate;
                    itemTemplate.ActionsOfSelfWhenUsed.ForEach(v => v.Cast(_stateManager, true));
                    itemTemplate.ActionsOfEnemyWhenUsed.ForEach(v => v.Cast(_stateManager, false));

                    inventoryItem.Amount.Value -= 1;

                    gameObject.SetActive(false);
                }
            };

            if (_amountObservable != null)
            {
                _amountObservable.Unsubscribe(_subscriberGuidOfItemAmountChangeOnButton);
            }

            _amountObservable = inventoryItem.Amount;
            
            _subscriberGuidOfItemAmountChangeOnButton = _amountObservable.Subscribe(amount =>
            {
                useButton.enabled = amount != 0;
            }, true);
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

            itemNameText.text = "";
            itemDescriptionText.text = "";
            itemImage.sprite = null;
            useButton.gameObject.SetActive(false);
        }
    }
}