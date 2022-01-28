using DefaultNamespace.Common;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace QuestScene.Ui
{
    public class QuestInventoryTabBehaviour : MonoBehaviour, IPointerClickHandler
    {
        public Image image;
        public bool isSelectedByDefault;

        public Color selectedColor;
        public Color nonSelectedColor;

        [HideInInspector] public SignalObservable OnSelected = new SignalObservable();

        private bool _isSelected;

        public void Start()
        {
            if (isSelectedByDefault)
            {
                image.color = selectedColor;
                OnSelected.Emit();
            }
            else
            {
                image.color = nonSelectedColor;
            }
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            OnSelected.Emit();
        }
    }
}