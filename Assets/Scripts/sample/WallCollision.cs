using System;
using UnityEngine;

namespace DefaultNamespace.sample
{
    public class WallCollision : MonoBehaviour
    {
        public void OnCollisionEnter(Collision other)
        {
            Debug.Log("On collision enter. this: " + gameObject.name + ", other: " + other.gameObject.name);
            gameObject.transform.position.Set(0, 0, 0);
        }

        public void OnCollisionStay(Collision other)
        {
            Debug.Log("On collision stay. this: " + gameObject.name + ", other: " + other.gameObject.name);
            gameObject.transform.position.Set(0, 0, 0);
        }

        public void OnCollisionExit(Collision other)
        {
            Debug.Log("On collision exit. this: " + gameObject.name + ", other: " + other.gameObject.name);
            gameObject.transform.position.Set(0, 0, 0);
        }
    }
}