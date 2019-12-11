using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace.MainPanel
{
    public class MainPanelPresenter : MonoBehaviour
    {
        public Text coinCountText;
        public Text statusLineText;
        
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
    }
}