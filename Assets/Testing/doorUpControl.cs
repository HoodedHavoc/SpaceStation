using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorUpControl : MonoBehaviour
{

    public bool openDoor = false;
    public bool closeDoor = false;

    public float openDistance = 2.5f;

    private float initialY;

    public Transform theKey;


    // Start is called before the first frame update
    void Start()
    {
        initialY = transform.localPosition.y;
    }

    private void OnTriggerEnter(Collider other)
    {
        openDoor = true;

        /*if (other.GetComponent<PlayerMove>().key == theKey)
            openDoor = true;*/
    }

    private void OnTriggerExit(Collider other)
    {
        closeDoor = true;
    }

    IEnumerator excecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        closeDoor = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (openDoor)
        {
            Vector3 move = transform.localPosition;
            move.y += 1.0f * Time.deltaTime;
            transform.localPosition = move;

            if (transform.localPosition.y > initialY + openDistance)
                openDoor = false;
        }


        if (closeDoor)
        {
            Vector3 move = transform.localPosition;
            move.y -= 1.0f * Time.deltaTime;
            transform.localPosition = move;

            if (transform.localPosition.y < initialY)
            {
                closeDoor = false;

                move.y = initialY;
                transform.localPosition = move;

            }

        }
    }

}
