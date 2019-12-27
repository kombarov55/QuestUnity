using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class CachedUserData : MonoBehaviour
    {
        public string currentSceneId;
        public int coinCount = 5;

        public List<string> openedJournalItems = new List<string>();
        public List<string> addedInventoryItems = new List<string>();

        public List<string> hiddenQuestNodes = new List<string>();
        
        public int unreadJournalItemsCount = 0;
        public int unseenInventoryItemsCount = 0;
    }
}