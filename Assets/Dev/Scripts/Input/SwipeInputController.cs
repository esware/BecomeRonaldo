using System;
using UnityEngine;

namespace Inputs
{
    public class SwipeInputController : MonoBehaviour
    {
        public float positionX;
        public float rotationY;

        private void Update()
        {
            MobileInput();
        }

        void MobileInput()
        {
            var mousePosition = Input.mousePosition;
            mousePosition.x -= Screen.width / 2.0f;

            if (Input.GetMouseButton(0))
            {
                rotationY = Mathf.Clamp(mousePosition.x, -45f, 45f);

                if (mousePosition.x < 0)
                {
                    positionX = .5f;
                }
                else if (mousePosition.x > 0)
                {
                    positionX = -.5f;
                }
            }
            else if (Input.GetMouseButtonUp(0))
            {
                positionX = 0;
                rotationY = 0;
            }
        }
    }
}