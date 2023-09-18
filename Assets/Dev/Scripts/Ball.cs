using System;
using System.Collections;
using UnityEngine;

namespace Dev.Scripts
{
    public class Ball : MonoBehaviour
    {
        private Rigidbody _rigidbody;
        public Rigidbody GetRigidbody => _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }
        
    }
    
}