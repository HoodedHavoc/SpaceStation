using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public CharacterController fpController;

    public float speed = 5f;
    public float gravity = -9.8f;

    // Checking if grounded and
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;
    
    Vector3 velocity;

    public Transform key;

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        fpController.Move(move * speed * Time.deltaTime);

        // Applies gravity, player falls
        velocity.y += gravity * Time.deltaTime;
        fpController.Move(velocity * Time.deltaTime);
    }
}
