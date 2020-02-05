using UnityEngine;

namespace DefaultNamespace.Scripts
{
    public class IgnoreCollisionScript : MonoBehaviour
    {

        public GameObject triggerPlane;
        public GameObject car;

        public void Start()
        {
//            Physics.IgnoreCollision(triggerPlane.GetComponent<Collider>(), car.GetComponentInChildren<Collider>());
        }
    }
}