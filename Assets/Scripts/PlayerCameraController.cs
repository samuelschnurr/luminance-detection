using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    private const float Y_ANGLE_MIN = -35f;
    private const float Y_ANGLE_MAX = 60f;
    private float mouseX, mouseY;
    public float RotationSpeed = 1;
    public Transform Target, Player;   

    void Start()
    {
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

    
    void ControlCamera()
    {
        transform.LookAt(Target);
        Target.rotation = Quaternion.Euler(mouseY, mouseX, 0);

        if (!Input.GetKey(KeyCode.LeftShift))
        {
            Player.rotation = Quaternion.Euler(0, mouseX, 0);
        }
    }
}
