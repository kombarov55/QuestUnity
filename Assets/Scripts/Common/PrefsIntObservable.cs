using UnityEngine;

namespace DefaultNamespace.Common
{
    public class PrefsIntObservable : Observable<int>
    {
        public PrefsIntObservable(string key) : base(0)
        {
            Value = PlayerPrefs.GetInt(key);
            Subscribe(v => PlayerPrefs.SetInt(key, v));
        }
    }
}