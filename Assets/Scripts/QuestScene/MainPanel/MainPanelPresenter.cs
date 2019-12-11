using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace.MainPanel
{
    public class MainPanelPresenter : MonoBehaviour
    {
        public Text coinCountText;

        public void setCoinCountText(int count)
        {
            coinCountText.text = "" + count;
        }
    }
}