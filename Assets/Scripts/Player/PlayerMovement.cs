using UnityEngine;

namespace Assets.Scripts.Player
{
    /// <summary>
    /// Player movement behaviour
    /// </summary>
    public class PlayerMovement : MonoBehaviour
    {
        public Transform GroundCheck;
        public LayerMask GroundMask;
        public float GroundDistance = 1f; // Equals the height of the player
        public float Speed = 10f;
        public float Gravity = -9.81f; // Default gravity of unity
        public float JumpHeight = 3f;
        private CharacterController controller;
        private Vector3 velocity;
        private float moveX;
        private float moveZ;
        private bool jump;
        private bool isGrounded;

        // Initialize once on start
        void Start()
        {
            controller = GetComponent<CharacterController>();
        }

        // Get Player Input for each frame
        void Update()
        {
            moveX = Input.GetAxis("Horizontal");
            moveZ = Input.GetAxis("Vertical");
            jump = Input.GetButtonDown("Jump");
            isGrounded = IsGrounded();

            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }

            Vector3 move = transform.right * moveX +
                           transform.forward * moveZ;
            controller.Move(move * Speed * Time.deltaTime);

            if (jump && isGrounded)
            {
                velocity.y = Mathf.Sqrt(JumpHeight * -2f * Gravity);
            }

            velocity.y += Gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        }

        private bool IsGrounded()
        {
            Ray rayToGround = new Ray(transform.position, Vector3.down);
            return Physics.Raycast(rayToGround, GroundDistance, GroundMask);
        }
    }
}