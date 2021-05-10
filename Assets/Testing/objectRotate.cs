using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectRotate : MonoBehaviour
{

    public GameObject ball;

    
    // Determine if object can rotate and/or move up and down
    public bool rotate = false;

    public bool upDown = false;


    public bool rotateLeft = true;

    public float moveDistance = 1.5f;

    public bool isUp = false;

    public bool isDown = true;

    private float initialPos;


    public float rotationSpeed = 10.0f;

    public float upDownSpeed = 10.0f;

    // The initial position of the object
    void Start()
    {
        initialPos = transform.localPosition.y;
    }

    void Update()
    {
        // Determine direction of rotation
        if (rotate == true)

        {
            if (rotateLeft == true)

                transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);

            else

                transform.Rotate(Vector3.down * rotationSpeed * Time.deltaTime);
        }


        // Moves object upwards
        if (upDown && isDown == true)
        {
            Vector3 move = transform.localPosition;
            move.y += 1.0f * upDownSpeed * Time.deltaTime;
            transform.localPosition = move;

            // If obejct is higher than the max moveDistance, then it's up
            if (transform.localPosition.y > initialPos + moveDistance)
            {
                isUp = true;
                isDown = false;
            }
                
        }

        // Moves object downwards
        if (upDown && isUp == true)

        {
            Vector3 move = transform.localPosition;
            move.y -= 1.0f * upDownSpeed * Time.deltaTime;
            transform.localPosition = move;

            // If object is lower than initialPos, then it's down
            if (transform.localPosition.y < initialPos)
            {
                isUp = false;
                isDown = true;
            }

        }
    }
}
