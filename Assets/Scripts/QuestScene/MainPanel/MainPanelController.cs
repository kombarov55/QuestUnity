using UnityEngine;

namespace DefaultNamespace.MainPanel
{
    public class MainPanelController : MonoBehaviour
    {
        private MainPanelPresenter mainPanelPresenter;
        private CachedUserData cachedUserData;

        private long statusLineStartTime = -1;

        private long statusLineDuration = 5000;

        public void init(CachedUserData cachedUserData)
        {
            this.cachedUserData = cachedUserData;
            
            mainPanelPresenter = GetComponent<MainPanelPresenter>();
            mainPanelPresenter.setCoinCountText(cachedUserData.coinCount);
        }

        public void decrementCoinCount()
        {
            if (cachedUserData.coinCount >= 1)
            {
                cachedUserData.coinCount = cachedUserData.coinCount - 1;
                mainPanelPresenter.setCoinCountText(cachedUserData.coinCount);
            }
        }

        public void openJournalItem(string noteId)
        {
            setStatusLineText("Открыта запись в журнале (" + noteId + ")");
        }
        

        public void setStatusLineText(string text)
        {
            statusLineStartTime = (long) Utils.currentTime(); 
            mainPanelPresenter.setStatusLineText(text);
        }

        public void Update()
        {
            if (statusLineStartTime != -1 && (Utils.currentTime() - statusLineStartTime) > statusLineDuration)
            {
                statusLineStartTime = -1;
                mainPanelPresenter.setStatusLineText("");
            }
        }
    }
}