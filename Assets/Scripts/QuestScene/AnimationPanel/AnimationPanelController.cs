using System;
using System.Collections;
using UnityEngine;

namespace DefaultNamespace.AnimationPanel
{
    public class AnimationPanelController : MonoBehaviour
    {
        public int duration = 3000;
        
        private AnimationPanelPresenter _animationPanelPresenter;
        private double startTime;

        private Action then;

        public void init()
        {
            _animationPanelPresenter = GetComponent<AnimationPanelPresenter>();
        }
        
        public void show(string imagePath, Action then)
        {
            gameObject.SetActive(true);
            startTime = currentTime();
            _animationPanelPresenter.showImage(imagePath);
            this.then = then;
        }

        public void Update()
        {
            if (then != null && isFinished())
            {
                stop();
            }
        }

        public void stop()
        {
            gameObject.SetActive(false);
            then.Invoke();
            then = null;
        }

        public bool isFinished()
        {
            var now = currentTime();
            var runningTime = now - startTime;
            Debug.Log("animation: " + runningTime);
            bool finished = runningTime > duration;
            return finished;
        }

        private double currentTime()
        {
            var datetime = DateTime.UtcNow - new DateTime(1970, 1, 1);
            double milliseconds = datetime.TotalMilliseconds;
            return milliseconds;
        }
    }
}