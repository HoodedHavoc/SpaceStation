using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorControl : MonoBehaviour
{

    public bool openDoor = false;
    public bool closeDoor = false;
    public bool stop = false;

    public float openDistance = -2.5f;

    private float initialX;

    public Transform theKey;


    // Start is called before the first frame update
    void Start()
    {
        initialX = transform.localPosition.x;
    }

    private void OnTriggerEnter(Collider other)
    {
        openDoor = true;

        /*if (other.GetComponent<PlayerMove>().key == theKey)
            openDoor = true;*/
    }

    // Update is called once per frame
    void Update()
    {
        if (openDoor)
        {
            Vector3 slidepos = transform.localPosition;
            slidepos.x -= 1.0f * Time.deltaTime;
            transform.localPosition = slidepos;

            if (transform.localPosition.x < initialX - openDistance)
                openDoor = false;
        }

        //if(stop)
        {
          //  initialX = openDistance;
        }
        /*  if (closeDoor)
        {
            Vector3 slidepos = transform.localPosition;
            slidepos.x += 1.0f * Time.deltaTime;
            transform.localPosition = slidepos;

            if (transform.localPosition.x < initialX)
            {
                closeDoor = false;

                slidepos.x = initialX;
                transform.localPosition = slidepos;

            }*/

        }
    }
