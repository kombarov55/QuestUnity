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
        public Color disabledColor = new Color(53, 53, 53);
        
        private Action<InventoryItem> _onClick;
        private InventoryItem _inventoryItem;
        private Color _enabledColor;

        public void Display(InventoryItem inventoryItem, Action<InventoryItem> onClick)
        {
            _inventoryItem = inventoryItem;
            _onClick = onClick;

            _enabledColor = image.color;
            
            image.sprite = Resources.Load<Sprite>(_inventoryItem.ItemTemplate.ImagePath);
            inventoryItem.Amount.Subscribe(amount =>
            {
                amountText.text = amount.ToString();
                
                image.color = amount == 0 ? disabledColor : _enabledColor;
            }, true);
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