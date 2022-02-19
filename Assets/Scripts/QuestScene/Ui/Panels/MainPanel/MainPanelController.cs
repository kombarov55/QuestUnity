using System.Collections.Generic;
using DefaultNamespace.Common;
using UnityEngine;

namespace DefaultNamespace.MainPanel
{
    public class MainPanelController : MonoBehaviour
    {
        private MainPanelPresenter mainPanelPresenter;
        private JournalItemsService journalItemsService;
        
        private GlobalSerializedState _globalSerializedState;

        private long statusLineStartTime = -1;

        private long statusLineDuration = 5000;

        public void init(JournalItemsService journalItemsService)
        {
            _globalSerializedState = GlobalSerializedState.Get();
            this.journalItemsService = journalItemsService;
            mainPanelPresenter = GetComponent<MainPanelPresenter>();
            mainPanelPresenter.setCoinCountText(_globalSerializedState.CoinCount.Value);
        }

        public void decrementCoinCount()
        {
            if (_globalSerializedState.CoinCount.Value >= 1)
            {
                _globalSerializedState.CoinCount.Value -= 1;
                mainPanelPresenter.setCoinCountText(_globalSerializedState.CoinCount.Value);
            }
        }

        public void openJournalItem(string noteId)
        {
            if (!journalItemsService.isJournalItemOpened(noteId))
            {
                setStatusLineText("Открыта запись в журнале (" + noteId + ")");
                journalItemsService.openJournalItem(noteId);
                incUnreadJournalItemsCounter(noteId);
            }
        }

        public void addInventoryItem(string itemId)
        {
            if (!_globalSerializedState.AddedInventoryItems.Contains(itemId))
            {
                _globalSerializedState.AddedInventoryItems[itemId] = 1;
                setStatusLineText("\"" + itemId + "\" добавлен в инвентарь.");
                incUnseenInventoryItemsCount(itemId);
            }
        }

        public void incUnreadJournalItemsCounter(string noteId)
        {
            
            mainPanelPresenter.SetJournalCounterText(_globalSerializedState.UnseenJournalItemIds.GetCopy().Count);
        }

        public void incUnseenInventoryItemsCount(string itemId)
        {
            _globalSerializedState.UnseenInventoryItemIds.Add(itemId);
            mainPanelPresenter.SetInventoryCounterText(_globalSerializedState.UnseenInventoryItemIds.GetCopy().Count);
        }

        public void dropUnreadJournalItemsCounter()
        {
            _globalSerializedState.UnseenJournalItemIds.SetValues(new List<string>());
            mainPanelPresenter.SetJournalCounterText(0);
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