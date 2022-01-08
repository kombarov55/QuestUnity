using System;
using System.Collections;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

namespace MainMenu.Controller
{
    public class HeartCountdownBehaviour : MonoBehaviour
    {
    
        private Text _text;

        private void Start()
        {
            _text = GetComponent<Text>();

            /*
             * - Отсчитать сколько сердечек восстановилось за время
             * - они восстанавливаются?
             *   - начать отсчёт
             *   - Поставить время на 30:00
             */

            RestoreLifes();
            
            if (Prefs.GetLifes() < GlobalConstants.MaxLifes)
            {
                StartCoroutine(StartCountdown());
            }
            else
            {
                _text.text = "00:00";
            }
        }

        private void RestoreLifes()
        {
            var lifes = Prefs.GetLifes();
            if (lifes == GlobalConstants.MaxLifes)
            {
                return;
            }
            
            DateTime lastLifeCountdownUpdate = Prefs.GetLastLifeCountdownUpdate();
            DateTime now = DateTime.Now;
            TimeSpan diff = now.Subtract(lastLifeCountdownUpdate);

            var lifesRestored = (int) diff.TotalMinutes / GlobalConstants.LifesCountdownInMinutes;

            if (lifes + lifesRestored <= GlobalConstants.MaxLifes)
            {
                Prefs.SetLifes(lifes + lifesRestored);

                int minutesSpent = GlobalConstants.LifesCountdownInMinutes * lifesRestored;
                DateTime dateTimeSinceLastHeartUpdate = lastLifeCountdownUpdate.AddMinutes(minutesSpent);

                Prefs.SetLastLifeCountdownUpdate(dateTimeSinceLastHeartUpdate);
            }
            else
            {
                Prefs.SetLifes(GlobalConstants.MaxLifes);
            }
        }
        
        private IEnumerator StartCountdown()
        {
            while (Prefs.GetLifes() < GlobalConstants.MaxLifes)
            {
                DateTime now = DateTime.Now;
                DateTime lastUpdate = Prefs.GetLastLifeCountdownUpdate();
                TimeSpan diff = now.Subtract(lastUpdate);
                TimeSpan cooldown = new TimeSpan(0, GlobalConstants.LifesCountdownInMinutes, 0);
                TimeSpan timeLeft =  cooldown.Subtract(diff);

                while (timeLeft.TotalSeconds > 0)
                {
                    _text.text = DateUtil.TimeSpanToString(timeLeft);
                    
                    yield return new WaitForSeconds(1);
                    
                    timeLeft = timeLeft.Subtract(TimeSpan.FromSeconds(1));
                } 
                
                Prefs.SetLifes(Prefs.GetLifes() + 1);
            } 
        }
    }
}