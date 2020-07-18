using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    private GameObject Light;

    void Start()
    {
        Light = GameObject.Find("Spot Light");
        Light.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Light.SetActive(!Light.activeSelf);
        }
    }
}
