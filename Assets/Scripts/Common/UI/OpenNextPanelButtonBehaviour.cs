using Other.MatchThreeGame.Assets.Scripts;
using UnityEngine;

namespace DefaultNamespace.Common.UI
{
    public class OpenNextPanelButtonBehaviour : MonoBehaviour
    {
        public GameObject whatToClose;
        public GameObject whatToOpen;
        public bool setFlagsOnStateManager = false;
        public bool flagValue;

        public void OnPointerClick()
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
                var stateManager = GameObject.Find("State").GetComponent<StateManager>();
                stateManager.IsAnyPanelDisplayedOnUI = flagValue;
            }
        }
    }
}