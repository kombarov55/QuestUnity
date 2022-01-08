using System;
using System.Collections;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

namespace MainMenu.Controller
{
    public class HeartCountdownBehaviour : MonoBehaviour
    {
        private readonly int _timeForNewLife = 30 * 60 * 1000;
        private int _currentTime = 30 * 60 * 1000;

        private Text _text;
        private CachedUserData _cachedUserData;
        
        private void Start()
        {
            _text = GetComponent<Text>();
            _cachedUserData = CachedUserData.Get();

            DisplayTime();
            StartCoroutine(StartCountdown());
        }

        public IEnumerator StartCountdown()
        {
            while (true)
            {
                while (_currentTime > 0)
                {
                    yield return new WaitForSeconds(1);
                    _currentTime -= 1000;
                    DisplayTime();
                }

                _currentTime = _timeForNewLife;
                _cachedUserData.ThreeInARowLifes += 1;
            }
        }

        private void DisplayTime()
        {
            DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            DateTime date = start.AddMilliseconds(_currentTime).ToLocalTime();
            string str = date.ToString("mm:ss");

            _text.text = str;
        }
    }
}