using System.Collections.Generic;
using DefaultNamespace.JournalPanel;
using DefaultNamespace.MainPanel;
using DefaultNamespace.model;
using UnityEngine;

namespace DefaultNamespace
{
    public class JournalItemsService : MonoBehaviour
    {
        private CachedUserData cachedUserData;

        public void Start()
        {
            cachedUserData = GetComponent<CachedUserData>();
        }
        
        public void init()
        {
            Start();
        }
        
        public List<JournalItem> GetOpenedJournalItems(JournalItemRepository journalItemRepository)
        {
            List<JournalItem> result = new List<JournalItem>();
            
            foreach (string id in cachedUserData.OpenedJournalItems)
            {
                result.Add(journalItemRepository.findById(id));
            }

            return result;
        }

        public void openJournalItem(string id)
        {
            if (!isJournalItemOpened(id))
            {
                cachedUserData.OpenJournalItem(id);
            }
        }

        public bool isJournalItemOpened(string id)
        {
            foreach (var itemId in cachedUserData.OpenedJournalItems)
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