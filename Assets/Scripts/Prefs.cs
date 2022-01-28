﻿using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DefaultNamespace
{
    public class Prefs
    {
        private static readonly string ThreeInARowLifesKey = "ThreeInARowLifes";
        private static readonly string LastLifeCountdownUpdateKey = "LastLifeCountdownUpdate";
        private static readonly string CurrentSceneIdKey = "CurrentSceneId";
        private static readonly string CoinCountKey = "CoinCount";

        private static Dictionary<string, Action<int>> _onLifesChangeSubscribers = new Dictionary<string, Action<int>>();
        private static Dictionary<string, Action<string>> _onLifesCountdownSubscribers = new Dictionary<string, Action<string>>();

        public static int ThreeInARowLifes
        {
            get => PlayerPrefs.GetInt(ThreeInARowLifesKey);
            set
            {
                PlayerPrefs.SetInt(ThreeInARowLifesKey, value);
                foreach (var pair in _onLifesChangeSubscribers)
                {
                    pair.Value.Invoke(value);
                }
            
                LastLifeCountdownUpdate = DateTime.Now;
            }
        }

        public static DateTime LastLifeCountdownUpdate
        {
            get => DateUtil.StringToDate(PlayerPrefs.GetString(LastLifeCountdownUpdateKey));
            set => PlayerPrefs.SetString(LastLifeCountdownUpdateKey, DateUtil.DateToString(value));
        }
        
        public static string CurrentSceneId
        {
            get => PlayerPrefs.GetString(CurrentSceneIdKey);
            set => PlayerPrefs.SetString(CurrentSceneIdKey, value);
        }

        public static int CoinCount
        {
            get => PlayerPrefs.GetInt(CoinCountKey);
            set => PlayerPrefs.SetInt(CoinCountKey, value);
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
            PlayerPrefs.SetInt("ThreeInARowLifes", 5);
        }
        
        private static void SaveList(string key, List<string> value)
        {
            PlayerPrefs.SetString(key, String.Join(",", value));            
        }

        private static List<string> ReadList(String key)
        {
            string value = PlayerPrefs.GetString("OpenedJournalItems");
            if (value == "")
            {
                return new List<string>();
            }

            return value.Split(',').ToList();
        }

        public static string SubscribeOnLifesChange(Action<int> action)
        {
            var guid = Guid.NewGuid().ToString();
            _onLifesChangeSubscribers.Add(guid, action);

            return guid;
        }

        public static void UnsubscribeOnLifesChange(string guid)
        {
            _onLifesChangeSubscribers.Remove(guid);
        }
        
        public static string SubscribeOnLifesCountdown(Action<string> action)
        {
            var guid = Guid.NewGuid().ToString();
            _onLifesCountdownSubscribers.Add(guid, action);

            return guid;
        }
        
        public static void UnsubscribeOnLifesCountdown(string guid)
        {
            _onLifesCountdownSubscribers.Remove(guid);
        }

        public static void SubmitCountdown(string text)
        {
            foreach (var pair in _onLifesCountdownSubscribers)
            {
                try
                {
                    pair.Value.Invoke(text);
                }
                catch (Exception e)
                {
                    Debug.LogError(e);
                }
            }
        }
        
    }
}