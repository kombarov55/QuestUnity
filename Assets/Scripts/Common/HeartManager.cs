using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace.Common
{
    public class HeartManager : MonoBehaviour
    {
        private GlobalSerializedState _globalSerializedState;
        
        void Start()
        {

            _globalSerializedState = GlobalSerializedState.Get();
            
            /*
             * - Отсчитать сколько сердечек восстановилось за время
             * - они восстанавливаются?
             *   - начать отсчёт
             *   - Поставить время на 30:00
           */
 
            RestoreLifes();
            
            if (_globalSerializedState.ThreeInARowLifes.Value < GlobalConstants.MaxLifes)
            {
                StartCoroutine(StartCountdown());
            }
        }
        
        private void RestoreLifes()
        {
            var lifes = _globalSerializedState.ThreeInARowLifes.Value;
            if (lifes == GlobalConstants.MaxLifes)
            {
                return;
            }

            DateTime lastLifeCountdownUpdate = _globalSerializedState.LastLifeCountdownUpdate.Value;
            DateTime now = DateTime.Now;
            TimeSpan diff = now.Subtract(lastLifeCountdownUpdate);

            var lifesRestored = (int) diff.TotalMinutes / GlobalConstants.LifesCountdownInMinutes;

            if (lifes + lifesRestored <= GlobalConstants.MaxLifes)
            {
                _globalSerializedState.ThreeInARowLifes.Value = lifes + lifesRestored;

                int minutesSpent = GlobalConstants.LifesCountdownInMinutes * lifesRestored;
                DateTime dateTimeSinceLastHeartUpdate = lastLifeCountdownUpdate.AddMinutes(minutesSpent);

                _globalSerializedState.LastLifeCountdownUpdate.Value = dateTimeSinceLastHeartUpdate;
            }
            else
            {
                _globalSerializedState.ThreeInARowLifes.Value = GlobalConstants.MaxLifes;
            }
        }
        
        private IEnumerator StartCountdown()
        {
            while (_globalSerializedState.ThreeInARowLifes.Value < GlobalConstants.MaxLifes)
            {
                DateTime now = DateTime.Now;
                DateTime lastUpdate = _globalSerializedState.LastLifeCountdownUpdate.Value;
                TimeSpan diff = now.Subtract(lastUpdate);
                TimeSpan cooldown = new TimeSpan(0, GlobalConstants.LifesCountdownInMinutes, 0);
                TimeSpan timeLeft =  cooldown.Subtract(diff);

                while (timeLeft.TotalSeconds > 0)
                {
                    GlobalState.LifesCountdownObservable.Value = DateUtil.TimeSpanToString(timeLeft); 
                    
                    yield return new WaitForSeconds(1);
                    
                    timeLeft = timeLeft.Subtract(TimeSpan.FromSeconds(1));
                }

                _globalSerializedState.ThreeInARowLifes.Value += 1;
            } 
        }
    }
}