using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace.MainPanel
{
    public class MainPanelPresenter : MonoBehaviour
    {
        public Text coinCountText;
        public Text statusLineText;
        public Button journalButton;
        public Button inventoryButton;
        
        public void setCoinCountText(int count)
        {
            coinCountText.text = "" + count;
        }
        
        public void setStatusLineText(string text)
        {
            statusLineText.text = text;
        }

        public bool hasStatusText()
        {
            var statusText = statusLineText.text;
            return statusText != null && statusText != "";
        }

        public void setJournalButtonText(string text)
        {
            journalButton.GetComponentInChildren<Text>().text = text;
        }

        public void setInventoryButtonText(string text)
        {
            inventoryButton.GetComponentInChildren<Text>().text = text;
        }
    }
}