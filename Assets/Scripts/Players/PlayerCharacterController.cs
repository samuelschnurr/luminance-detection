using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterController : MonoBehaviour
{
    public LayerMask GroundLayers;
    public float JumpForce = 5f;
    public float DistanceToGround = 1f;
    public float MoveSpeed = 10f;
    private Rigidbody rBody; 

    void Start()
    {
        rBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = 0f;
        float moveZ = Input.GetAxis("Vertical");

        Vector3 playerMovement = new Vector3(moveX, moveY, moveZ).normalized * Time.deltaTime * MoveSpeed;
        transform.Translate(playerMovement, Space.Self);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rBody.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
        }
    }

    private bool IsGrounded()
    {
        Ray rayToGround = new Ray(transform.position, Vector3.down);
        return Physics.Raycast(rayToGround, DistanceToGround, GroundLayers);
    }
}
