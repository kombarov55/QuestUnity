using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DefaultNamespace.Common
{
    public class PrefsListOfStringObservable : ListObservable<string>
    {
        public PrefsListOfStringObservable(string key) : base(new List<string>())
        {
            SetValues(ReadList(key));
            SubscribeForChanges(list => SaveList(key, list));
        }

        private static List<string> ReadList(string key)
        {
            string value = PlayerPrefs.GetString(key);
            if (value == "")
            {
                return new List<string>();
            }

            return value.Split(',').ToList();            
        }
        
        private static void SaveList(string key, List<string> list) 
        {
            PlayerPrefs.SetString(key, String.Join(",", list));
        }

    }
}