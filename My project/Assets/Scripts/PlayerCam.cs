using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public float sensx;
    public float sensy;

    public Transform orientation;

    float xRotation;
    float yRotation;

    private void Start()
    {
        //lock the mouse to the middle of the screen
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void Update()
    {
        //get mouse input
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensx;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensy;

        yRotation += mouseX;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //rotate cam & orientation
        transform.rotation = Quaternion.Euler(xRotation,yRotation, 0);
        orientation.rotation = Quaternion.Euler(0,yRotation, 0);

    }
}
