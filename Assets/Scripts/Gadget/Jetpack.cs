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

        public CharacterController CharController;
        public float Speed = 3f;
        public float MaxForce = 15f; // Force you can use
        public float ForceMultiplier = 0.25f; // Multiplier for the movement force
        private Vector3 currentVector = Vector3.up;
        public float CurrentForce = 0f; // Force currently in use
        private bool CanUseJetpack = true;

        // JetPack is on hold jump button, so FixedUpdate() which may not run every single frame is enough
        // FixedUpdate runs for each frame when physics calculations happen
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
            currentVector += transform.right * Input.GetAxis("Horizontal");
            currentVector += transform.forward * Input.GetAxis("Vertical");
            CharController.Move((currentVector * Speed * Time.fixedDeltaTime - CharController.velocity * Time.fixedDeltaTime) * CurrentForce * ForceMultiplier);
        }
    }
}
