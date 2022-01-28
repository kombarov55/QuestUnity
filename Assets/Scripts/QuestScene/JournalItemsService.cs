using System.Collections.Generic;
using DefaultNamespace.JournalPanel;
using DefaultNamespace.MainPanel;
using DefaultNamespace.model;
using UnityEngine;

namespace DefaultNamespace
{
    public class JournalItemsService : MonoBehaviour
    {
        private CachedPrefs _cachedPrefs;

        public void Start()
        {
            _cachedPrefs = GetComponent<CachedPrefs>();
        }
        
        public void init()
        {
            Start();
        }
        
        public List<JournalItem> GetOpenedJournalItems(JournalItemRepository journalItemRepository)
        {
            List<JournalItem> result = new List<JournalItem>();
            
            foreach (string id in _cachedPrefs.OpenedJournalItems)
            {
                result.Add(journalItemRepository.findById(id));
            }

            return result;
        }

        public void openJournalItem(string id)
        {
            if (!isJournalItemOpened(id))
            {
                _cachedPrefs.OpenJournalItem(id);
            }
        }

        public bool isJournalItemOpened(string id)
        {
            foreach (var itemId in _cachedPrefs.OpenedJournalItems)
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