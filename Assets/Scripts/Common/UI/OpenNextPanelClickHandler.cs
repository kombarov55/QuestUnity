using Other.MatchThreeGame.Assets.Scripts;
using UnityEngine;
using UnityEngine.EventSystems;

namespace DefaultNamespace.Common.UI
{
    public class OpenNextPanelClickHandler : MonoBehaviour, IPointerClickHandler
    {
        public GameObject whatToClose;
        public GameObject whatToOpen;
        public bool setFlagsOnStateManager = false;
        public bool flagValue;

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

            if (setFlagsOnStateManager)
            {
                var stateManager = StateManager.Get();
                stateManager.IsAnyPanelDisplayedOnUI = flagValue;
            }
        }
    }
}