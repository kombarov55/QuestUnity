using System;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class Prefs
    {
        private static readonly string LifesKey = "ThreeInARowLifes";
        private static readonly string LastLifeCountdownUpdateKey = "LastLifeCountdownUpdateKey";

        private static Dictionary<string, Action<int>> _onLifesChangeSubscribers = new Dictionary<string, Action<int>>();
        
        public static int GetLifes()
        {
            return PlayerPrefs.GetInt(LifesKey);
        }

        public static void SetLifes(int amount)
        {
            PlayerPrefs.SetInt(LifesKey, amount);
            foreach (var pair in _onLifesChangeSubscribers)
            {
                pair.Value.Invoke(amount);
            }
            
            SetLastLifeCountdownUpdate(DateTime.Now);
        }

        public static DateTime GetLastLifeCountdownUpdate()
        {
            return DateUtil.StringToDate(PlayerPrefs.GetString(LastLifeCountdownUpdateKey));
        }

        public static void SetLastLifeCountdownUpdate(DateTime dateTime)
        {
            PlayerPrefs.SetString(LastLifeCountdownUpdateKey, DateUtil.DateToString(dateTime));
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
        
    }
}