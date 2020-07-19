using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterController : MonoBehaviour
{
    public float Speed = 10f;
    public float Gravity = -9.81f; // Default gravity of unity
    public float JumpHeight = 5f;
    private CharacterController controller;
    //private PlayerInput input;
    private Vector3 velocity;

    public Transform groundCheck;
    public float groundDistance = 1f; // Equals the height of the player
    public LayerMask groundMask;

    // Initialize once on start
    void Start()
    {
        controller = GetComponent<CharacterController>();
        //input = GetComponent<PlayerInput>();
    }

    void Update()
    {
        if (IsGrounded() && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        controller.Move(move * Speed * Time.deltaTime);

        print("Grounded: " + IsGrounded());

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {

            velocity.y = Mathf.Sqrt(JumpHeight * -2f * Gravity);
        }
        velocity.y += Gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);


    }

    private bool IsGrounded()
    {
        Ray rayToGround = new Ray(transform.position, Vector3.down);
        return Physics.Raycast(rayToGround, groundDistance, groundMask);
    }
}
