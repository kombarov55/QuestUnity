using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace DefaultNamespace.MainPanel
{
    public class MainPanelPresenter : MonoBehaviour
    {
        public Text coinCountText;
        public Text statusLineText;
        public Text _inventoryCounterText;
        public Text _journalCounterText;
        public Image _inventoryCounterBackground;
        public Image _journalCounterBackground;

        public void setCoinCountText(int count)
        {
            coinCountText.text = "x " + count;
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

        public void SetJournalCounterText(int amount)
        {
            _journalCounterText.text = "" + amount;
            _journalCounterBackground.gameObject.SetActive(amount != 0);
            _journalCounterText.gameObject.SetActive(amount != 0);
        }
        
        public void SetInventoryCounterText(int amount)
        {
            _inventoryCounterText.text = "" + amount;
            _inventoryCounterBackground.gameObject.SetActive(amount != 0);
            _inventoryCounterText.gameObject.SetActive(amount != 0);
        }
    }
}