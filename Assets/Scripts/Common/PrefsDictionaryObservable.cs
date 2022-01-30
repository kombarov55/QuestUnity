using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DefaultNamespace.Common
{
    public class PrefsDictionaryObservable : DictionaryObservable<string, int>
    {
        private static readonly string WithinEntriesDelimiter = ",%";
        
        public PrefsDictionaryObservable(string key) : base(new Dictionary<string, int>())
        {
            SetValues(ReadValues(key));
            SubscribeOnChanges(dict => SaveValues(key, dict));
        }

        private void SaveValues(string key, Dictionary<string, int> dict)
        {
            var str = String.Join(
                "@",
                dict.Keys.Select(key => key + "#" + dict[key])
            );
            PlayerPrefs.SetString(key, str);
            
        }
        
        private Dictionary<string, int> ReadValues(string key)
        {
            var str = PlayerPrefs.GetString(key);
            if (str == "")
            {
                return new Dictionary<string, int>();
            }
            
            var tupleList = str.Split('@')
                .Select(str =>
                {
                    var splitted = str.Split('#');
                    return new Tuple<string, int>(splitted[0], int.Parse(splitted[1]));
                });
            Dictionary<string, int> result = new Dictionary<string, int>();
            foreach (var tuple in tupleList)
            {
                result[tuple.Item1] = tuple.Item2;
            }
            
            return result;
        }
    }
}