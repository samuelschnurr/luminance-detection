using UnityEngine;

namespace Assets.Scripts.Player
{
    /// <summary>
    /// Basi class for player input
    /// </summary>
    public class PlayerInput : MonoBehaviour
    {
        public float MoveX { get; private set; }
        public float MoveZ { get; private set; }
        public float MouseX { get; private set; }
        public float MouseY { get; private set; }
        public bool Jump { get; private set; }
        public bool JumpHold { get; private set; }
        public bool FlashLight { get; set; }

        // Use Update() to get the user input per each frame
        // Player input will not be get lost on slow/fast frame rates
        void Update()
        {
            MoveX = Input.GetAxis("Horizontal");
            MoveZ = Input.GetAxis("Vertical");
            MouseX = Input.GetAxis("Mouse X");
            MouseY = Input.GetAxis("Mouse Y");
            Jump = Input.GetButtonDown("Jump");
            JumpHold = Input.GetKey(KeyCode.Space);

            if (Input.GetKeyDown(KeyCode.F))
            {
                FlashLight = true;
            }
        }
    }
}
