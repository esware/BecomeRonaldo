using System;
using UnityEngine;

public class BallPhysics : MonoBehaviour
{
    [Header("Ball Physics")] 
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float gravityMultiplier;
    [SerializeField] private AnimationCurve fallingCurve;

    private Rigidbody _rigidbody;
    private bool isGrounded = false;

    private Vector3 _velocity;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        
    }

    private bool IsGrounded()
    {
        isGrounded = Physics.CheckSphere(transform.position, 0.5f, groundLayer);
        return isGrounded;
    }

    private void ApplyFallingPhysics()
    {
        float fallingFactor = fallingCurve.Evaluate(1f - Mathf.Clamp01(_rigidbody.velocity.y / gravityMultiplier));
        _velocity = Vector3.down * (gravityMultiplier * fallingFactor);
        _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, _velocity.y, _rigidbody.velocity.z);
    }
}
