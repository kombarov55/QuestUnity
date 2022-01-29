using System.Collections.Generic;
using DefaultNamespace.Common;
using DefaultNamespace.JournalPanel;
using DefaultNamespace.MainPanel;
using DefaultNamespace.model;
using UnityEngine;

namespace DefaultNamespace
{
    public class JournalItemsService : MonoBehaviour
    {
        private GlobalSerializedState _globalSerializedState;

        public void init()
        {
            _globalSerializedState = GlobalSerializedState.Get();
        }
        
        public List<JournalItem> GetOpenedJournalItems(JournalItemRepository journalItemRepository)
        {
            List<JournalItem> result = new List<JournalItem>();
            
            foreach (string id in _globalSerializedState.OpenedJournalItemIds.GetCopy())
            {
                result.Add(journalItemRepository.findById(id));
            }

            return result;
        }

        public void openJournalItem(string id)
        {
            if (!isJournalItemOpened(id))
            { 
                _globalSerializedState.OpenedJournalItemIds.Add(id);
            }
        }

        public bool isJournalItemOpened(string id)
        {
            foreach (var itemId in _globalSerializedState.OpenedJournalItemIds.GetCopy())
            {
                if (itemId == id)
                {
                    return true;
                }
            }

            return false;
        }
    }
}