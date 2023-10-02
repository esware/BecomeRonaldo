using UnityEngine;

namespace Dev.Scripts.Character.PlayerStates
{
    public class PlayerRunState:BaseState<PlayerController>
    {
        public PlayerRunState(PlayerController controller) : base(controller)
        {
            controller.RunningState();
        }

        public override void Update()
        {
            
        }

        public override void FixedUpdate()
        {
            controller.playerMovementController.Move();
        }
    }
}