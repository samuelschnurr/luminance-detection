using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private float moveX, moveZ;
    private float mouseX, mouseY;
    private bool jump;    
    public float MoveX => moveX;
    public float MoveZ => moveZ;
    public float MouseX => mouseX;
    public float MouseZ => mouseZ;
    public bool Jump => jump;

    // Get Player Input for each frame
    void Update()
    {
        moveX = Input.GetAxis("Horizontal");
        moveZ = Input.GetAxis("Vertical");

        mouseX += Input.GetAxis("Mouse X");
        mouseY -= Input.GetAxis("Mouse Y");

        jump = Input.GetButton("Jump");
    }
}
