using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
