using UnityEngine;

namespace DefaultNamespace.MainPanel
{
    public class MainPanelController : MonoBehaviour
    {
        private MainPanelPresenter mainPanelPresenter;
        private CachedPrefs _cachedPrefs;
        private JournalItemsService journalItemsService;

        private long statusLineStartTime = -1;

        private long statusLineDuration = 5000;

        public void init(CachedPrefs cachedPrefs, JournalItemsService journalItemsService)
        {
            this._cachedPrefs = cachedPrefs;
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
            if (!_cachedPrefs.AddedInventoryItems.Contains(id))
            {
                _cachedPrefs.AddInventoryItem(id);
                setStatusLineText("\"" + id + "\" добавлен в инвентарь.");
                incUnseenInventoryItemsCount();
            }
        }

        public void incUnreadJournalItemsCounter()
        {
            _cachedPrefs.UnreadJournalItemsCount += 1;
            mainPanelPresenter.SetJournalCounterText(_cachedPrefs.UnreadJournalItemsCount);
        }

        public void incUnseenInventoryItemsCount()
        {
            _cachedPrefs.UnseenInventoryItemsCount += 1;
            mainPanelPresenter.SetInventoryCounterText(_cachedPrefs.UnseenInventoryItemsCount);
        }

        public void dropUnreadJournalItemsCounter()
        {
            _cachedPrefs.UnreadJournalItemsCount = 0;
            mainPanelPresenter.SetJournalCounterText(0);
        }
        
        public void dropUnseenInventoryItemsCount()
        {
            _cachedPrefs.UnseenInventoryItemsCount = 0;
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