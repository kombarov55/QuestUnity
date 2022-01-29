using UnityEngine;

namespace DefaultNamespace.Common
{
    public class PrefsBoolObservable : Observable<bool>
    {
        public PrefsBoolObservable(string key) : base(false)
        {
            Value = PlayerPrefs.GetInt(key) == 1;
            Subscribe(v => PlayerPrefs.SetInt(key, v ? 1 : 0));
        }
    }
}