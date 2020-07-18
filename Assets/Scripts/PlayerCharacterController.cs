using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterController : MonoBehaviour
{
    public float MoveSpeed;

    void Start()
    {
        MoveSpeed = 10;
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = 0f;
        float moveZ = Input.GetAxis("Vertical");

        Vector3 playerMovement = new Vector3(moveX, moveY, moveZ).normalized * Time.deltaTime * MoveSpeed;

        transform.Translate(playerMovement, Space.Self);
    }
}
