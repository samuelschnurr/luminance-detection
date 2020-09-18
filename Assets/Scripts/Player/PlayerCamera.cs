using UnityEngine;

namespace Assets.Scripts.Player
{
    /// <summary>
    /// Player camera behaviour
    /// </summary>
    public class PlayerCamera : MonoBehaviour
    {
        public float RotationSpeed = 100f;
        private const float Y_ANGLE_MIN = -35f;
        private const float Y_ANGLE_MAX = 60f;
        private GameObject player;
        private float mouseX, mouseY;

        void Start()
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            player = GameObject.FindWithTag("Player");
        }

        void FixedUpdate()
        {
            mouseX += Input.GetAxis("Mouse X") * RotationSpeed;
            mouseY -= Input.GetAxis("Mouse Y") * RotationSpeed;
            mouseY = Mathf.Clamp(mouseY, Y_ANGLE_MIN, Y_ANGLE_MAX);
            transform.rotation = Quaternion.Euler(mouseY, mouseX, 0);
            player.transform.rotation = Quaternion.Euler(0, mouseX, 0);
        }
    }
}