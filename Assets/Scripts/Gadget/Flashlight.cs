using UnityEngine;

namespace Assets.Scripts.Gadget
{
    /// <summary>
    /// A simple flashlight
    /// </summary>
    public class Flashlight : MonoBehaviour
    {
        private GameObject spotlight;

        void Start()
        {
            spotlight = GameObject.Find("Spot Light");
            spotlight.SetActive(true);
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                spotlight.SetActive(!spotlight.activeSelf);
            }
        }
    }
}
