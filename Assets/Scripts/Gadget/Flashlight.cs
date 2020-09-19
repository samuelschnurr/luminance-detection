using Assets.Scripts.Player;
using UnityEngine;

namespace Assets.Scripts.Gadget
{
    /// <summary>
    /// A simple flashlight
    /// </summary>
    public class Flashlight : MonoBehaviour
    {
        private PlayerInput playerInput;
        private GameObject spotlight;

        void Start()
        {
            playerInput = GetComponentInParent<PlayerInput>();
            spotlight = GameObject.Find("Spot Light");
            spotlight.SetActive(true);
        }

        void Update()
        {
            ToggleFlashlight();
        }

        private void ToggleFlashlight()
        {
            if (playerInput.FlashLight)
            {
                playerInput.FlashLight = false;
                spotlight.SetActive(!spotlight.activeSelf);
            }
        }
    }
}
