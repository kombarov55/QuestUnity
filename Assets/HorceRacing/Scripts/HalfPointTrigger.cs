using System;
using UnityEngine;

namespace DefaultNamespace.Scripts
{
    public class HalfPointTrigger : MonoBehaviour
    {
        public GameObject halfTrigger;
        public GameObject lapCompleteTrigger;
        
        public void OnCollisionEnter(Collision other)
        {
            lapCompleteTrigger.SetActive(true);
            halfTrigger.SetActive(false);
        }
    }
}