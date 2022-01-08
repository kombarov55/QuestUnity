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

        private int _threeInARowLifes;

        public void Load()
        {
            CurrentSceneId = PlayerPrefs.GetString("CurrentSceneId");
            _coinCount = PlayerPrefs.GetInt("CoinCount");
            _openedJournalItems = PlayerPrefs.GetString("OpenedJournalItems").Split(',').ToList();
            _addedInventoryItems = PlayerPrefs.GetString("AddedInventoryItems").Split(',').ToList();
            _hiddenQuestNodes = PlayerPrefs.GetString("HiddenQuestNodes").Split(',').ToList();
            _unreadJournalItemsCount = PlayerPrefs.GetInt("UnreadJournalItemsCount");
            _unseenInventoryItemsCount = PlayerPrefs.GetInt("UnseenInventoryItemsCount");
            _threeInARowLifes = PlayerPrefs.GetInt("ThreeInARowLifes");
        }

        public static CachedUserData Get()
        {
            var v = new CachedUserData();
            v.Load();
            return v;
        }

        public static void Reset()
        {
            PlayerPrefs.SetInt("IsGameStarted", 1);
            PlayerPrefs.SetString("CurrentSceneId", QuestSceneConstants.FIRST_NODE_ID);
            PlayerPrefs.SetInt("CoinCount", 5);
            SaveList("OpenedJournalItems", new List<string>());
            SaveList("AddedInventoryItems", new List<string>());
            SaveList("HiddenQuestNodes", new List<string>());
            PlayerPrefs.SetInt("UnreadJournalItemsCount", 0);
            PlayerPrefs.SetInt("UnseenInventoryItemsCount", 0);
            PlayerPrefs.SetInt("ThreeInARowLifes", 6);
        }

        public static bool IsGameStarted()
        {
            return PlayerPrefs.GetInt("IsGameStarted") == 1;
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

        public int ThreeInARowLifes
        {
            get => _threeInARowLifes; 
            set 
            {
                PlayerPrefs.SetInt("ThreeInARowLifes", value);
                _threeInARowLifes = value;
            }
        }

        private static void SaveList(string key, List<string> value)
        {
            PlayerPrefs.SetString(key, String.Join(",", value));            
        }
    }
}