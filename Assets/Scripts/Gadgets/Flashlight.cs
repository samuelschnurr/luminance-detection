using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    private GameObject light;

    void Start()
    {
        light = GameObject.Find("Spot Light");
        light.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            light.SetActive(!light.activeSelf);
        }
    }
}
