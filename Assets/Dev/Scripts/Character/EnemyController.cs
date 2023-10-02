using System;
using System.Collections;
using Managers;
using UnityEngine;
using UnityEngine.AI;

namespace Dev.Scripts.Character
{
    public class EnemyController:MonoBehaviour
    {
        [Space,Header("Force Variables")]
        public float forcePower=10f;
        public float enemySpeed = 1f;
        
        private Collider[] _colliders;
        private Rigidbody[] _rigidbodies;
        private Animator _animator;
        private Rigidbody _rigidbody;
        private NavMeshAgent _agent;
        private PlayerController _playerController;

        private bool _canFollow = false;

        private void Awake()
        {
            SignUpEvents();
        }

        private void Start()
        {
            _colliders = GetComponentsInChildren<Collider>();
            _rigidbodies = GetComponentsInChildren<Rigidbody>();
            _animator = GetComponent<Animator>();
            _rigidbody = GetComponent<Rigidbody>();
            _agent = GetComponent<NavMeshAgent>();
            _playerController = FindObjectOfType<PlayerController>();

            DeactivateRagdoll();
        }

        private void SignUpEvents()
        {
            GameEvents.RunEvent += GoTarget;
        }
        private void ActivateRagdoll()
        {
            _agent.enabled = false;
            _animator.enabled = false;
            _rigidbody.useGravity = true;
            _rigidbody.isKinematic = false;
            
            foreach (var rigidbody in _rigidbodies)
            {
                rigidbody.useGravity = true;
                rigidbody.isKinematic = false;
            }

            foreach (var collider in _colliders)
            {
                collider.isTrigger = false;
            }
        }
        
        private void DeactivateRagdoll()
        {
            _agent.enabled = true;
            _animator.enabled = true;
            _rigidbody.useGravity = false;
            _rigidbody.isKinematic = true;
            
            foreach (var r in _rigidbodies)
            {
                r.useGravity = false;
                r.isKinematic = true;
            }

            foreach (var c in _colliders)
            {
                c.isTrigger = true;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                ActivateRagdoll();

                var direction = other.transform.position- transform.position;
                
                _rigidbody.AddForce(direction*forcePower,ForceMode.Impulse);
                GameEvents.RunEvent?.Invoke();
            }
        }

        private void Update()
        {
            if (_canFollow)
            {
                if (_animator.enabled)
                {
                    _agent.destination = _playerController.transform.position;

                    _agent.speed = enemySpeed;
                    _animator.speed = _agent.speed*0.2f;
                    _agent.updateRotation = true;
                }
            }
        }

        void GoTarget()
        {
            _canFollow = true;
            _animator.SetBool("Run",true);
        }
    }
}