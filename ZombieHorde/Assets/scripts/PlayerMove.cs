using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public GameObject PlayerRotate;

    private CharacterController controller;
    public float playerSpeed;
    public float _rotationSpeed = 180;
    public float playerVelocity;

    public static int collectedItems = 0;

    Vector3 mouse_pos;
    Vector3 object_pos;
    float angle;
    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    void Update()
    {
        mouse_pos = Input.mousePosition;
        object_pos = Camera.main.WorldToScreenPoint(PlayerRotate.transform.position); //takes the mouse position on screen and finds the position in world space
        mouse_pos.x = mouse_pos.x - object_pos.x;
        mouse_pos.y = mouse_pos.y - object_pos.y;
        angle = Mathf.Atan2(mouse_pos.x, mouse_pos.y) * Mathf.Rad2Deg; //takes the angle between the player and mouse world position, converts it to degrees from radiants 
        PlayerRotate.transform.rotation = Quaternion.Euler(0, angle, 0); //rotates the player asset towards the mouse position

        Vector3 move = new Vector3(Input.GetAxisRaw("Horizontal") * Time.deltaTime, playerVelocity, Input.GetAxisRaw("Vertical") * Time.deltaTime); // takes horizontal and vertical input and applys to the vector 3 move
        move = this.transform.TransformDirection(move);
        controller.Move(move * playerSpeed); // takes the move vector 3 and uses unity's character controller to move the player in the move vector 3 direction, also applying player speed


        if (controller.isGrounded)
        {
            playerVelocity = 0f;
        }else { playerVelocity = -0.005f; }
    }

}