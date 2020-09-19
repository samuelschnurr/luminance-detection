using UnityEngine;

namespace Assets.Scripts.Player
{
    /// <summary>
    /// Player camera behaviour
    /// </summary>
    public class PlayerCamera : MonoBehaviour
    {
        public float RotationSpeed = 1f;
        private const float Y_ANGLE_MIN = -35f;
        private const float Y_ANGLE_MAX = 60f;
        private GameObject player;
        private PlayerInput playerInput;
        private float mouseX, mouseY;

        void Start()
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            player = GameObject.FindWithTag("Player");
            playerInput = GetComponentInParent<PlayerInput>();
        }

        void Update()
        {
            CalculateCameraMovement();
        }

        // Execute camera movement after all physics happened
        void LateUpdate()
        {
            MoveCamera();
        }

        private void CalculateCameraMovement()
        {
            mouseX += playerInput.MouseX * RotationSpeed;
            mouseY -= playerInput.MouseY * RotationSpeed;
            mouseY = Mathf.Clamp(mouseY, Y_ANGLE_MIN, Y_ANGLE_MAX);
        }

        private void MoveCamera()
        {
            transform.rotation = Quaternion.Euler(mouseY, mouseX, 0);
            player.transform.rotation = Quaternion.Euler(0, mouseX, 0);
        }
    }
}