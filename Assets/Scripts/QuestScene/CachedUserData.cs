using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DefaultNamespace
{
    public class CachedUserData : MonoBehaviour
    {

        private string _currentSceneId;
        private int _coinCount;
        private List<string> _openedJournalItems;
        private List<string> _addedInventoryItems;
        private List<string> _hiddenQuestNodes;
        private int _unreadJournalItemsCount;
        private int _unseenInventoryItemsCount;

        public void Load()
        {
            CurrentSceneId = PlayerPrefs.GetString("CurrentSceneId");
            CoinCount = _currentSceneId == "" ? 5 : PlayerPrefs.GetInt("CoinCount");
            OpenedJournalItems = _currentSceneId == ""
                ? new List<string>()
                : PlayerPrefs.GetString("OpenedJournalItems").Split(',').ToList();
            AddedInventoryItems = _currentSceneId == ""
                ? new List<string>()
                : PlayerPrefs.GetString("AddedInventoryItems").Split(',').ToList();
            HiddenQuestNodes = _currentSceneId == ""
                ? new List<string>()
                : PlayerPrefs.GetString("HiddenQuestNodes").Split(',').ToList();
            UnreadJournalItemsCount = _currentSceneId == "" ? 0 : PlayerPrefs.GetInt("UnreadJournalItemsCount");
            UnseenInventoryItemsCount = _currentSceneId == "" ? 0 : PlayerPrefs.GetInt("UnseenInventoryItemsCount");
        }

        public static bool IsGameStarted()
        {
            return PlayerPrefs.GetString("CurrentSceneId") != "";
        }

        public static void Reset()
        {
            PlayerPrefs.DeleteKey("CurrentSceneId");
        }
        
        public string CurrentSceneId
        {
            get => _currentSceneId;
            set
            {
                PlayerPrefs.SetString("CurrentSceneId", value);
                _currentSceneId = value;
            }
        }

        public int CoinCount
        {
            get => _coinCount;
            set
            {
                PlayerPrefs.SetInt("CoinCount", value);
                _coinCount = value;
            }
        }

        public List<string> OpenedJournalItems
        {
            get => _openedJournalItems;

            set
            {
                PlayerPrefs.SetString("OpenedJournalItems", String.Join(",", value));
                _openedJournalItems = value;
            }
        }

        public List<string> AddedInventoryItems
        {
            get => _addedInventoryItems;
            set
            {
                PlayerPrefs.SetString("AddedInventoryItems", String.Join(",", value));
                _addedInventoryItems = value;
            }
        }

        public List<string> HiddenQuestNodes
        {
            get => _hiddenQuestNodes;
            set
            {
                PlayerPrefs.SetString("HiddenQuestNodes", String.Join(",", value));
                _hiddenQuestNodes = value;
            }
        }

        public int UnreadJournalItemsCount
        {
            get => _unreadJournalItemsCount;
            set
            {
                PlayerPrefs.SetInt("UnreadJournalItemsCount", UnreadJournalItemsCount);
                _unreadJournalItemsCount = value;
            }
        }

        public int UnseenInventoryItemsCount
        {
            get => _unseenInventoryItemsCount;
            set
            {
                PlayerPrefs.SetInt("UnseenInventoryItemsCount", UnseenInventoryItemsCount);
                _unseenInventoryItemsCount = value;
            }
        }

        public void OpenJournalItem(string itemId)
        {
            _openedJournalItems.Add(itemId);
            SaveList("OpenedJournalItems", _openedJournalItems);
        }
        
        public void AddInventoryItem(string itemId)
        {
            _addedInventoryItems.Add(itemId);
            SaveList("AddedInventoryItems", _addedInventoryItems);
        }
        
        public void HideQuestNode(string questNodeId)
        {
            _hiddenQuestNodes.Add(questNodeId);
            SaveList("HiddenQuestNodes", _hiddenQuestNodes);
        }

        private void SaveList(string key, List<string> value)
        {
            PlayerPrefs.SetString(key, String.Join(",", value));            
        }
    }
}