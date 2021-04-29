using Assets.Scripts.Player;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Gadget
{
    /// <summary>
    /// A simple flashlight
    /// </summary>
    public class Flashlight : MonoBehaviour
    {
        private NavMeshObstacle navMeshObstacle;
        private PlayerInput playerInput;
        private GameObject spotlight;

        void Start()
        {
            navMeshObstacle = GetComponentInParent<NavMeshObstacle>();
            playerInput = GetComponentInParent<PlayerInput>();
            spotlight = GameObject.Find("Spot Light");
            spotlight.SetActive(true);
        }

        void Update()
        {
            if (playerInput.FlashLight)
            {
                playerInput.FlashLight = false;
                ToggleFlashlight();
            }
        }

        private void ToggleFlashlight()
        {
            spotlight.SetActive(!spotlight.activeSelf);
            RearrangeNavMeshObstacle(spotlight.activeSelf);
        }

        private void RearrangeNavMeshObstacle(bool spotLightActive)
        {
            if (spotLightActive)
            {
                // Obstacle is bigger to the front to avoid light
                navMeshObstacle.center = new Vector3(0, 0, 1.75f);
                navMeshObstacle.size = new Vector3(2, 1, 5);
            }
            else
            {
                // Obstacle has small size to every side
                navMeshObstacle.center = new Vector3(0, 0, 0);
                navMeshObstacle.size = new Vector3(1.5f, 1, 1.5f);
            }
        }
    }
}
