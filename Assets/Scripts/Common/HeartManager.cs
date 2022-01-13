using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace.Common
{
    public class HeartManager : MonoBehaviour
    {
        void Start()
        {
            
            /*
             * - Отсчитать сколько сердечек восстановилось за время
             * - они восстанавливаются?
             *   - начать отсчёт
             *   - Поставить время на 30:00
           */
 
            RestoreLifes();
            
            if (Prefs.ThreeInARowLifes < GlobalConstants.MaxLifes)
            {
                StartCoroutine(StartCountdown());
            }
        }
        
        private void RestoreLifes()
        {
            var lifes = Prefs.ThreeInARowLifes;
            if (lifes == GlobalConstants.MaxLifes)
            {
                return;
            }

            DateTime lastLifeCountdownUpdate = Prefs.LastLifeCountdownUpdate;
            DateTime now = DateTime.Now;
            TimeSpan diff = now.Subtract(lastLifeCountdownUpdate);

            var lifesRestored = (int) diff.TotalMinutes / GlobalConstants.LifesCountdownInMinutes;

            if (lifes + lifesRestored <= GlobalConstants.MaxLifes)
            {
                Prefs.ThreeInARowLifes = lifes + lifesRestored;

                int minutesSpent = GlobalConstants.LifesCountdownInMinutes * lifesRestored;
                DateTime dateTimeSinceLastHeartUpdate = lastLifeCountdownUpdate.AddMinutes(minutesSpent);

                Prefs.LastLifeCountdownUpdate = dateTimeSinceLastHeartUpdate;
            }
            else
            {
                Prefs.ThreeInARowLifes = GlobalConstants.MaxLifes;
            }
        }
        
        private IEnumerator StartCountdown()
        {
            while (Prefs.ThreeInARowLifes < GlobalConstants.MaxLifes)
            {
                DateTime now = DateTime.Now;
                DateTime lastUpdate = Prefs.LastLifeCountdownUpdate;
                TimeSpan diff = now.Subtract(lastUpdate);
                TimeSpan cooldown = new TimeSpan(0, GlobalConstants.LifesCountdownInMinutes, 0);
                TimeSpan timeLeft =  cooldown.Subtract(diff);

                while (timeLeft.TotalSeconds > 0)
                {
                    Prefs.SubmitCountdown(DateUtil.TimeSpanToString(timeLeft));
                    
                    yield return new WaitForSeconds(1);
                    
                    timeLeft = timeLeft.Subtract(TimeSpan.FromSeconds(1));
                }

                Prefs.ThreeInARowLifes = Prefs.ThreeInARowLifes + 1;
            } 
        }
    }
}