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
        private bool CanUseJetpack = true;
        private float CurrentForce = 0f; // Force currently in use        
        private float moveX;
        private float moveZ;

        void Start()
        {
            playerInput = GetComponentInParent<PlayerInput>();
            controller = GetComponentInParent<CharacterController>();
        }

        // Use Update() to get the user input per each frame
        void Update()
        {
            moveX = Input.GetAxis("Horizontal");
            moveZ = Input.GetAxis("Vertical");
        }

        // FixedUpdate() runs for each frame when physics calculations happen
        // Execute movement when physics happen with input of the last frame
        void FixedUpdate()
        {
            CheckOverheat();

            if (Input.GetKey(KeyCode.Space) && CanUseJetpack)
            {
                UseForce();
                UseJetPack();
            }
            else
            {
                ReloadForce();
            }
        }

        private void CheckOverheat()
        {
            bool isOverheated = CurrentForce >= MaxForce;

            if (isOverheated)
            {
                CanUseJetpack = false;
            }
            else if (CurrentForce <= 0)
            {
                CanUseJetpack = true;
            }
        }

        private void UseForce()
        {
            CurrentForce += Time.deltaTime * FORCE_CONSUMPTION;
        }

        private void ReloadForce()
        {
            CurrentForce -= Time.deltaTime * FORCE_FILLUP;

            if (CurrentForce < 0)
            {
                CurrentForce = 0;
            }
        }

        private void UseJetPack()
        {
            currentVector = Vector3.up;
            currentVector += transform.right * moveX;
            currentVector += transform.forward * moveZ;
            controller.Move((currentVector * Speed * Time.fixedDeltaTime - controller.velocity * Time.fixedDeltaTime) * CurrentForce * ForceMultiplier);
        }
    }
}
