using System;
using System.Collections.Generic;

namespace DefaultNamespace
{
    public class PrefsDefaultValues
    {
        public static readonly int CoinCount = 5;
        public static readonly string CurrentSceneId = "Письмо";
        public static readonly bool IsGameStarted = false;
        public static readonly int ThreeInARowLifes = GlobalConstants.MaxLifes;
        public static readonly DateTime LastLifeCountdownUpdate = DateTime.Now;
        public static readonly List<string> OpenedJournalItemIds = new List<string>();
        public static readonly Dictionary<string, int> AddedInventoryItemIds = new Dictionary<string, int>();
        
        public static readonly List<string> HiddenQuestNodeIds = new List<string>();
        public static readonly List<string> UnseenJournalItemIds = new List<string>();
        public static readonly List<string> UnseenInventoryItemIds = new List<string>();
    }
}