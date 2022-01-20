using System;
using Other.MatchThreeGame.Assets.Scripts.Model;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Other.MatchThreeGame.Assets.Scripts.UI
{
    public class ItemBehaviour : MonoBehaviour, IPointerClickHandler
    {
        public Image image;
        public Text amountText;
        
        private Action<InventoryItem> _onClick;
        private InventoryItem _inventoryItem;

        public void Display(InventoryItem inventoryItem, Action<InventoryItem> onClick)
        {
            _inventoryItem = inventoryItem;
            _onClick = onClick;
            
            image.sprite = Resources.Load<Sprite>(_inventoryItem.ItemTemplate.ImagePath);
            inventoryItem.Amount.Subscribe(value => amountText.text = value.ToString(), true);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (_onClick != null)
            {
                _onClick.Invoke(_inventoryItem);
            }
        }
    }
}