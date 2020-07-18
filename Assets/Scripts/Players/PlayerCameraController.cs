using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    private const float Y_ANGLE_MIN = -35f;
    private const float Y_ANGLE_MAX = 60f;

    public float RotationSpeed = 1f;    
    private Transform target, player;    
    private float mouseX, mouseY;        

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        target = GameObject.FindWithTag("Target").transform;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        mouseX += Input.GetAxis("Mouse X") * RotationSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * RotationSpeed;
        mouseY = Mathf.Clamp(mouseY, Y_ANGLE_MIN, Y_ANGLE_MAX);
    }

    void LateUpdate()
    {
        ControlCamera();
    }

    
    private void ControlCamera()
    {
        transform.LookAt(target);
        target.rotation = Quaternion.Euler(mouseY, mouseX, 0);

        if (!Input.GetKey(KeyCode.LeftShift))
        {
            player.rotation = Quaternion.Euler(0, mouseX, 0);
        }
    }
}
