using System;
using UnityEngine;

namespace DefaultNamespace.Scripts
{
    public class TriggerPoint : MonoBehaviour
    {

        public Vector3 impulse;

        public void OnTriggerEnter(Collider other)
        {
            Debug.Log("Enter trigger point");
        }
    }
}