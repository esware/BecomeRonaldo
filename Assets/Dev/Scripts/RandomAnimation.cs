using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAnimation : StateMachineBehaviour
{
    [SerializeField] private int animationCount;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        int randomIndex = Random.Range(0, animationCount);
        animator.Play(randomIndex.ToString(),0);
    }

    public override void OnStateUpdate(Animator animator,AnimatorStateInfo stateInfo, int layerIndex)
    {
        int randomIndex = Random.Range(0, animationCount);
        animator.Play(randomIndex.ToString(),0);
    }
}
