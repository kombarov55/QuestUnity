using UnityEngine;
using UnityEngine.EventSystems;

namespace DefaultNamespace.Common.UI
{
    public class OpenNextPanelClickHandler : MonoBehaviour, IPointerClickHandler
    {
        public GameObject whatToClose;
        public GameObject whatToOpen;

        public void OnPointerClick(PointerEventData eventData)
        {
            if (whatToClose != null)
            {
                whatToClose.SetActive(false);                
            }
            
            if (whatToOpen != null)
            {
                whatToOpen.SetActive(true);
            }
        }
    }
}