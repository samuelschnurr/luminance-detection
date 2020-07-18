using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    private GameObject Light;

    public bool ToggleLight;

    void Start()
    {
        Light = GameObject.FindWithTag("Flashlight");
        Light.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Light.SetActive(!Light.activeSelf);
        }
    }
}
