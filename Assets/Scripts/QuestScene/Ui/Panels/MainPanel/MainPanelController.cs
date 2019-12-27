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
            if (!journalItemsService.isJournalItemOpened(noteId))
            {
                setStatusLineText("Открыта запись в журнале (" + noteId + ")");
                journalItemsService.openJournalItem(noteId);
                incUnreadJournalItemsCounter();
            }
        }

        public void addInventoryItem(string id)
        {
            if (!cachedUserData.addedInventoryItems.Contains(id))
            {
                cachedUserData.addedInventoryItems.Add(id);
                setStatusLineText("\"" + id + "\" добавлен в инвентарь.");
                incUnseenInventoryItemsCount();
            }
        }

        public void incUnreadJournalItemsCounter()
        {
            cachedUserData.unreadJournalItemsCount += 1;
            mainPanelPresenter.setJournalButtonText("Журнал (" + cachedUserData.unreadJournalItemsCount + ")");
        }

        public void incUnseenInventoryItemsCount()
        {
            cachedUserData.unseenInventoryItemsCount += 1;
            mainPanelPresenter.setInventoryButtonText("Инвентарь (" + cachedUserData.unseenInventoryItemsCount + ")");
        }

        public void dropUnreadJournalItemsCounter()
        {
            cachedUserData.unreadJournalItemsCount = 0;
            mainPanelPresenter.setJournalButtonText("Журнал");
        }
        
        public void dropUnseenInventoryItemsCount()
        {
            cachedUserData.unseenInventoryItemsCount = 0;
            mainPanelPresenter.setInventoryButtonText("Инвентарь");
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