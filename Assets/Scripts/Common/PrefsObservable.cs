using UnityEngine;

namespace DefaultNamespace.Common
{
    public class PrefsStringObservable : Observable<string>
    {
        public PrefsStringObservable(string key) : base("")
        {
            Value = PlayerPrefs.GetString(key);
            Subscribe(v => PlayerPrefs.SetString(key, v));
        }
    }
}