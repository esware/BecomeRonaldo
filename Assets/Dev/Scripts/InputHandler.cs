using UnityEngine;

namespace Dev.Scripts
{
    public class InputHandler : MonoBehaviour
    {
        public Vector3 mousePosition;

        private void GetMousePosition()
        {
            mousePosition = Input.mousePosition;
            
        }
    }
}