using UnityEngine;

namespace DefaultNamespace.Common.UI
{
    public class MoveBehaviour : MonoBehaviour
    {
        public float distanceX = 0;
        public float distanceY = 10;
        public float durationInSeconds = 1;

        public void Run()
        {
            var targetPosition = new Vector2(transform.position.x + distanceX, transform.position.y + distanceY);
            
            transform.positionTo(durationInSeconds, targetPosition);
        }
    }
}