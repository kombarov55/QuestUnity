using UnityEngine;

namespace DefaultNamespace.MainPanel
{
    public class MainPanelController : MonoBehaviour
    {
        private MainPanelPresenter mainPanelPresenter;
        private CachedUserData cachedUserData;
        private JournalItemsService journalItemsService;

        private long statusLineStartTime = -1;

        private long statusLineDuration = 5000;

        public void init(CachedUserData cachedUserData, JournalItemsService journalItemsService)
        {
            this.cachedUserData = cachedUserData;
            this.journalItemsService = journalItemsService;
            mainPanelPresenter = GetComponent<MainPanelPresenter>();
            mainPanelPresenter.setCoinCountText(Prefs.CoinCount);
        }

        public void decrementCoinCount()
        {
            if (Prefs.CoinCount >= 1)
            {
                Prefs.CoinCount -= 1;
                mainPanelPresenter.setCoinCountText(Prefs.CoinCount);
            }
        }

        public void openJournalItem(string noteId)
        {
            if (!journalItemsService.isJournalItemOpened(noteId))
            {
                setStatusLineText("Открыта запись в журнале (" + noteId + ")");
                journalItemsService.openJournalItem(noteId);
                incUnreadJournalItemsCounter();
            }
        }

        public void addInventoryItem(string id)
        {
            if (!cachedUserData.AddedInventoryItems.Contains(id))
            {
                cachedUserData.AddInventoryItem(id);
                setStatusLineText("\"" + id + "\" добавлен в инвентарь.");
                incUnseenInventoryItemsCount();
            }
        }

        public void incUnreadJournalItemsCounter()
        {
            cachedUserData.UnreadJournalItemsCount += 1;
            mainPanelPresenter.SetJournalCounterText(cachedUserData.UnreadJournalItemsCount);
        }

        public void incUnseenInventoryItemsCount()
        {
            cachedUserData.UnseenInventoryItemsCount += 1;
            mainPanelPresenter.SetInventoryCounterText(cachedUserData.UnseenInventoryItemsCount);
        }

        public void dropUnreadJournalItemsCounter()
        {
            cachedUserData.UnreadJournalItemsCount = 0;
            mainPanelPresenter.SetJournalCounterText(0);
        }
        
        public void dropUnseenInventoryItemsCount()
        {
            cachedUserData.UnseenInventoryItemsCount = 0;
            mainPanelPresenter.SetInventoryCounterText(0);
        }

        public void setStatusLineText(string text)
        {
            statusLineStartTime = Utils.currentTime();
            mainPanelPresenter.setStatusLineText(text);
        }

        public void Update()
        {
            if (statusLineStartTime == -1 && mainPanelPresenter != null && mainPanelPresenter.hasStatusText())
            {
                statusLineStartTime = Utils.currentTime();
            }

            if (statusLineStartTime != -1 && (Utils.currentTime() - statusLineStartTime) > statusLineDuration)
            {
                statusLineStartTime = -1;
                mainPanelPresenter.setStatusLineText("");
            }
        }
    }
}