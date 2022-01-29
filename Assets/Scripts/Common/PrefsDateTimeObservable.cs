using System;
using UnityEngine;

namespace DefaultNamespace.Common
{
    public class PrefsDateTimeObservable : Observable<DateTime>
    {

        public PrefsDateTimeObservable(string key) : base(new DateTime())
        {
            Value = DateUtil.StringToDate(PlayerPrefs.GetString((key)));
            Subscribe(v => PlayerPrefs.SetString(key, DateUtil.DateToString(v)));
        }
        
    }
}