using UnityEngine;

namespace Dev.Scripts.Character.PlayerStates
{
    public class PlayerIdleState:BaseState<PlayerController>
    {
        public PlayerIdleState(PlayerController controller) : base(controller)
        {
            controller.IdleState();
        }

        public override void Update()
        {
            
        }

        public override void FixedUpdate()
        {
            
        }
    }
}