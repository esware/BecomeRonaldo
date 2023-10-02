using Dev.Scripts.Character;
using Dev.Scripts.Character.PlayerStates;
using DG.Tweening;
using Inputs;
using Managers;
using UnityEngine;

public enum AnimationStates
{
    Idle,Run
}

[RequireComponent(typeof(Rigidbody)),RequireComponent(typeof(PlayerMovementController)),RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    [HideInInspector] public BaseState<PlayerController> CurrentState; 
    
    public PlayerMovementController playerMovementController;
    
    
    private Animator _animator;
    private Collider[] _colliders;
    private Rigidbody[] _rigidbodies;
    private Rigidbody _rigidbody;

    
    
    void Start()
    {
        InitComponents();
        SignUpEvents();
    }

    void InitComponents()
    {
        _colliders = GetComponentsInChildren<Collider>();
        _rigidbodies = GetComponentsInChildren<Rigidbody>();
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
        
        playerMovementController ??= GetComponent<PlayerMovementController>();

        CurrentState = new PlayerIdleState(this);
    }

    void SignUpEvents()
    {
        GameEvents.RunEvent +=()=> ChangeState(new  PlayerRunState(this));
    }
    
    private void ActivateRagdoll()
    {
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
    
    void Update()
    {
        CurrentState.Update();
    }

    void FixedUpdate()
    {
        CurrentState.FixedUpdate();
    }

    #region States
    
    public void IdleState()
    {
        DeactivateRagdoll();
        PlayAnim(AnimationStates.Idle,0.1f);
    }

    public void RunningState()
    {
        PlayAnim(AnimationStates.Run,0.1f);
    }

    



    public void DeathState()
    {
        ActivateRagdoll();
    }

    public void PlayAnim(AnimationStates animationState,float  animationTransitionSpeed)
    {
        if(_animator.IsInTransition(0)) {return;}
        _animator.CrossFade(animationState.ToString(), animationTransitionSpeed);
    }

    public void ChangeState(BaseState<PlayerController> newState)
    {
        CurrentState = newState;
    }
    

    #endregion

}
