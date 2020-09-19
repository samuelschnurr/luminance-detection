using UnityEngine;

namespace Assets.Scripts.Player
{
    /// <summary>
    /// Player movement behaviour
    /// </summary>
    [RequireComponent(typeof(CharacterController))]
    [RequireComponent(typeof(PlayerInput))]
    public class PlayerMovement : MonoBehaviour
    {
        public Transform GroundCheck;
        public LayerMask GroundMask;
        public float GroundDistance = 1f; // Equals the height of the player
        public float Speed = 10f;
        public float Gravity = -9.81f; // Default gravity of unity
        public float JumpHeight = 3f;
        private CharacterController controller;
        private PlayerInput playerInput;
        private Vector3 velocity;

        // Initialize once on start
        void Start()
        {
            controller = GetComponent<CharacterController>();
            playerInput = GetComponent<PlayerInput>();
        }

        // FixedUpdate() runs for each frame when physics calculations happen
        // Execute movement when physics happen with input of the last frame
        void FixedUpdate()
        {
            Move();
            Jump();
        }

        private bool IsGrounded()
        {
            Ray rayToGround = new Ray(transform.position, Vector3.down);
            return Physics.Raycast(rayToGround, GroundDistance, GroundMask);
        }

        private void Move()
        {
            Vector3 move = transform.right * playerInput.MoveX + transform.forward * playerInput.MoveZ;
            controller.Move(move * Speed * Time.deltaTime);
        }

        private void Jump()
        {
            bool isGrounded = IsGrounded();

            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }

            if (playerInput.Jump && isGrounded)
            {
                velocity.y = Mathf.Sqrt(JumpHeight * -2f * Gravity);
            }

            velocity.y += Gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        }
    }
}
