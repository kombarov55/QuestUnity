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
        
        private Action<StoredItem> _onClick;
        private StoredItem _storedItem;
        private Color _enabledColor;

        public void Display(StoredItem storedItem, Action<StoredItem> onClick)
        {
            _storedItem = storedItem;
            _onClick = onClick;

            _enabledColor = image.color;
            
            image.sprite = Resources.Load<Sprite>(_storedItem.ItemRepository.ImagePath);
            storedItem.Amount.Subscribe(amount =>
            {
                amountText.text = amount.ToString();
                
                image.color = amount == 0 ? disabledColor : _enabledColor;
            }, true);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (_onClick != null)
            {
                _onClick.Invoke(_storedItem);
            }
        }
    }
}