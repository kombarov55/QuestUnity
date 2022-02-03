using System;
using DefaultNamespace.Common;
using UnityEngine;
using UnityEngine.Events;

namespace Other.MatchThreeGame.Assets.Scripts
{
    public class SwipeDetector : MonoBehaviour
    {
        public float swipeThreshold = 50f;
        public float timeThreshold = 0.3f;

        private Vector2 fingerDown;
        private DateTime fingerDownTime;
        private Vector2 fingerUp;
        private DateTime fingerUpTime;

        public static Observable<Tuple<Vector2, Direction>> OnSwipe =
            new Observable<Tuple<Vector2, Direction>>(new Tuple<Vector2, Direction>(new Vector2(), Direction.Up));

        private void Update () {
            if (Input.GetMouseButtonDown(0)) {
                fingerDown = Input.mousePosition;
                fingerUp = Input.mousePosition;
                fingerDownTime = DateTime.Now;
            }
            if (Input.GetMouseButtonUp(0)) {
                fingerDown = Input.mousePosition;
                fingerUpTime = DateTime.Now;
                CheckSwipe();
            }
            foreach (Touch touch in Input.touches) {
                if (touch.phase == TouchPhase.Began) {
                    fingerDown = touch.position;
                    fingerUp = touch.position;
                    fingerDownTime = DateTime.Now;
                }
                if (touch.phase == TouchPhase.Ended) {
                    fingerDown = touch.position;
                    fingerUpTime = DateTime.Now;
                    CheckSwipe();
                }
            }
        }

        private void CheckSwipe() {
            float duration = (float)fingerUpTime.Subtract(fingerDownTime).TotalSeconds;
            if (duration > timeThreshold) return;

            float deltaX = fingerDown.x - fingerUp.x;
            float deltaY = fingerDown.y - fingerUp.y;

            if (Math.Abs(deltaX) > Math.Abs(deltaY))
            {
                if (Mathf.Abs(deltaX) > swipeThreshold) {
                    if (deltaX > 0) {
                        OnSwipe.Emit(new Tuple<Vector2, Direction>(fingerUp, Direction.Right));
                    
                        // OnSwipeRight.Invoke();
                        //Debug.Log("right");
                    } else if (deltaX < 0) {
                        OnSwipe.Emit(new Tuple<Vector2, Direction>(fingerUp, Direction.Left));
                        // OnSwipeLeft.Invoke();
                        //Debug.Log("left");
                    }
                }                
            }
            else
            {
                if (Mathf.Abs(deltaY) > swipeThreshold) {
                    if (deltaY > 0) {
                        // OnSwipeUp.Invoke();
                        OnSwipe.Emit(new Tuple<Vector2, Direction>(fingerUp, Direction.Up));
                        //Debug.Log("up");
                    } else if (deltaY < 0) {
                        OnSwipe.Emit(new Tuple<Vector2, Direction>(fingerUp, Direction.Down));
                        // OnSwipeDown.Invoke();
                        //Debug.Log("down");
                    }
                }                
            }
            

            fingerUp = fingerDown;
        }
    }
}