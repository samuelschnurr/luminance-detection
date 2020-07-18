using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public GameObject Light;
    public bool ToggleLight;

    void Start()
    {
        Light.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            ToggleLight = true;
        }

        // Toggle can also be used from the insepctor view
        if (ToggleLight)
        {
            Light.SetActive(!Light.activeSelf);
            ToggleLight = false;
        }
    }
}
