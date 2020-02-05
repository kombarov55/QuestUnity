using System;
using UnityEngine;

namespace DefaultNamespace.sample
{
    public class MoveBehaviour : MonoBehaviour
    {
        public float speed;

        void Update()
        {
            var w = Input.GetAxisRaw("Horizontal");
            var h = Input.GetAxisRaw("Vertical");

            var x = transform.position.x;
            var y = transform.position.y;
            var z = transform.position.z;

            transform.position = new Vector3(x + (w * speed), y, z +  (h * speed));
        }

        public void OnCollisionEnter(Collision other)
        {
            Debug.Log("Hit something");
        }
    }
}