using System;
using DefaultNamespace.Model;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace QuestScene.Ui
{
    public class QuestInventoryItemBehaviour : MonoBehaviour, IPointerClickHandler
    {

        public Image image;
        public Text amountText;
        public Image amountBackground;
        
        private Action _onClick;

        public void Display(StoredItem storedItem, Action onClick)
        {
            _onClick = onClick;


            image.sprite = Resources.Load<Sprite>(storedItem.Item.imgPath);

            if (storedItem.Amount > 1)
            {
                amountText.text = storedItem.Amount.ToString();
            }
            else
            {
                amountBackground.gameObject.SetActive(false);
            }
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (_onClick != null) 
            {
                _onClick.Invoke();
            }
        }
    }
}