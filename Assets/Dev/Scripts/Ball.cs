using System;
using System.Collections;
using UnityEngine;

namespace Dev.Scripts
{
    public class Ball : MonoBehaviour
    {
        private Rigidbody _rigidbody;
        public Rigidbody GetRigidbody => _rigidbody;

        public PhysicMaterial ballPhysics;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Target"))
            {
                ballPhysics.bounciness = 0.1f;
                ballPhysics.dynamicFriction = 0.7f;
            }
        }
    }
    
}