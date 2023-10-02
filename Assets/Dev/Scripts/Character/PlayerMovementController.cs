using System;
using Inputs;
using UnityEngine;

namespace Dev.Scripts.Character
{
    [RequireComponent(typeof(SwipeInputController))]
    public class PlayerMovementController : MonoBehaviour
    {
        [SerializeField] private float platformXBoundaries;
        [SerializeField] private float speed;
        private SwipeInputController _inputController;
        private Rigidbody _rigidbody;

        private void Start()
        {
            InitComponents();
        }
        
        void InitComponents()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _inputController = GetComponent<SwipeInputController>();
        }

        public void Move()
        {
            Vector3 direction = Vector3.back;
            direction += new Vector3(_inputController.positionX, 0, 0);

            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, _inputController.rotationY, 0), speed * Time.fixedDeltaTime);

            Vector3 normalizedDirection = direction.normalized;
            Vector3 newPosition = transform.position + normalizedDirection * (speed * Time.deltaTime);

            newPosition.x = Mathf.Clamp(newPosition.x, -platformXBoundaries, platformXBoundaries);

            _rigidbody.MovePosition(newPosition);
        }
    }
}