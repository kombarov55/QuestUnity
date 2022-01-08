using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class Prefs
    {
        private static readonly string LifesKey = "ThreeInARowLifes";
        private static readonly string LastLifeCountdownUpdateKey = "LastLifeCountdownUpdateKey";
        
        public static int GetLifes()
        {
            return PlayerPrefs.GetInt(LifesKey);
        }

        public static void SetLifes(int lifes)
        {
            PlayerPrefs.SetInt(LifesKey, lifes);
        }

        public static DateTime GetLastLifeCountdownUpdate()
        {
            return DateUtil.StringToDate(PlayerPrefs.GetString(LastLifeCountdownUpdateKey));
        }

        public static void SetLastLifeCountdownUpdate(DateTime dateTime)
        {
            PlayerPrefs.SetString(LastLifeCountdownUpdateKey, DateUtil.DateToString(dateTime));
        }
        
    }
}