//Built using the Brackeys FPS controller tutorial: https://www.youtube.com/watch?v=_QajrabyTJc

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementBrackeys : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    //Juicey grav is above -30
    public float gravity = -9.81f;
    //Juicy jump is 3.5 ish
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    //Ah fuck
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        //Called to check if on the ground. New function in PHysics.checksphere
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            //May want to change this variable to be 0f, set to -2f to force the player on the ground
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

        }
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
