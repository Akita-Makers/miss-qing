using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private float cameraSpeed = 0.2f; //how fast does the camera move smoothly to its target destination
    [SerializeField]
    private Transform playerTransform; //the transform of the player
    [SerializeField]
    private Vector3 cameraOffset; //the position offset of its target

    [Header("Bounds")]
    [SerializeField]
    public float XBoundPointMin; //at what minimum x position can the camera show
    [SerializeField]
    public float XBoundPointMax; //at what maximum x position can the camera show
    [SerializeField]
    public float YBoundPointMin; //at what minimum y position can the camera show
    [SerializeField]
    public float YBoundPointMax; //at what maximum y position can the camera show

    [SerializeField]
    private Camera cam; 

    private Vector3 moveVelocity; //a value for smoothdamp to use
    private Vector3 targetPosition; //the position the camera wants to move towards

    //how big is the screen size by world coordinates
    private float horizontalScreenSize; 
    private float verticalScreenSize;

    private void Start()
    {
        transform.position = GetTargetPosition(); //when the game starts the camera goes to the position of the player
    }

    private void FixedUpdate()
    {
        // //calculates the screen size so that the camera knows where the sides of the screens are in units
        // horizontalScreenSize = cam.orthographicSize * Screen.width / Screen.height; //converts the horizontal screen size into units
        // verticalScreenSize = cam.orthographicSize; //converts the vertical screen size into units
        
        // //calculates the x coordinate of the target position
        // //makes sure that the camera cant be in a position where the screen is outside of the bounds for the x axis
        // float targetXPos = Mathf.Clamp(playerTransform.position.x + cameraOffset.x, XBoundPointMin + horizontalScreenSize, XBoundPointMax - horizontalScreenSize);

        // //calculates the y coordinate of the target position
        // //makes sure that the camera cant be in a position where the screen is outside of the bounds for the y axis
        // float targetYPos = Mathf.Clamp(playerTransform.position.y + cameraOffset.y, YBoundPointMin + verticalScreenSize, YBoundPointMax - verticalScreenSize);

        // //set what was calculated into the target position
        // targetPosition = new Vector3(targetXPos, targetYPos, transform.position.z);

        //smoothly moves the camera's position towards the target position
        transform.position = Vector3.SmoothDamp(transform.position, GetTargetPosition(), ref moveVelocity, cameraSpeed);
    }

    public Vector3 GetTargetPosition()
    {
        //calculates the screen size so that the camera knows where the sides of the screens are in units
        horizontalScreenSize = cam.orthographicSize * Screen.width / Screen.height; //converts the horizontal screen size into units
        verticalScreenSize = cam.orthographicSize; //converts the vertical screen size into units
        
        //calculates the x coordinate of the target position
        //makes sure that the camera cant be in a position where the screen is outside of the bounds for the x axis
        float targetXPos = Mathf.Clamp(playerTransform.position.x + cameraOffset.x, XBoundPointMin + horizontalScreenSize, XBoundPointMax - horizontalScreenSize);

        //calculates the y coordinate of the target position
        //makes sure that the camera cant be in a position where the screen is outside of the bounds for the y axis
        float targetYPos = Mathf.Clamp(playerTransform.position.y + cameraOffset.y, YBoundPointMin + verticalScreenSize, YBoundPointMax - verticalScreenSize);

        //set what was calculated into the target position
        return new Vector3(targetXPos, targetYPos, transform.position.z);
    }
}