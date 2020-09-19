using Assets.Scripts.Player;
using UnityEngine;

namespace Assets.Scripts.Gadget
{
    /// <summary>
    /// A jetpack which allows you to fly
    /// </summary>
    public class Jetpack : MonoBehaviour
    {
        private const float FORCE_CONSUMPTION = 10f; // Using jetpack fuel costs factor 10 to the time
        private const float FORCE_FILLUP = 3f; // Reloading jetpack by factor 2 to the time

        public float Speed = 3f;
        public float MaxForce = 15f; // Force you can use
        public float ForceMultiplier = 0.25f; // Multiplier for the movement force
        private CharacterController controller;
        private PlayerInput playerInput;
        private Vector3 currentVector = Vector3.up;
        private bool isForceRemaining = true;
        private bool isJetpackUsable = true;
        private float currentForce = 0f; // Force currently in use        

        void Start()
        {
            playerInput = GetComponentInParent<PlayerInput>();
            controller = GetComponentInParent<CharacterController>();
        }

        void Update()
        {
            CheckForceRemaining();

            if (playerInput.JumpHold && isForceRemaining)
            {
                isJetpackUsable = true;
                currentVector = CalculateJetpackMovement();
                UseForce();
            }
            else
            {
                isJetpackUsable = false;
                ReloadForce();
            }
        }

        // FixedUpdate() runs for each frame when physics calculations happen
        // Execute movement when physics happen with input of the last frame
        void FixedUpdate()
        {
            if (isJetpackUsable)
            {
                UseJetPack();
            }
        }

        private void CheckForceRemaining()
        {
            bool forceEmpty = currentForce >= MaxForce;

            if (forceEmpty)
            {
                // Jetpack is overheated
                isForceRemaining = false;
            }
            else if (currentForce <= 0)
            {
                // Jetpack is cooled down
                isForceRemaining = true;
            }
        }

        private void UseForce()
        {
            currentForce += Time.deltaTime * FORCE_CONSUMPTION;
        }

        private void ReloadForce()
        {
            currentForce -= Time.deltaTime * FORCE_FILLUP;

            if (currentForce < 0)
            {
                currentForce = 0;
            }
        }

        private Vector3 CalculateJetpackMovement()
        {
            currentVector = Vector3.up;
            currentVector += transform.right * playerInput.MoveX;
            currentVector += transform.forward * playerInput.MoveZ;
            return currentVector;
        }

        private void UseJetPack()
        {
            controller.Move((currentVector * Speed * Time.fixedDeltaTime - controller.velocity * Time.fixedDeltaTime) * currentForce * ForceMultiplier);
        }
    }
}
