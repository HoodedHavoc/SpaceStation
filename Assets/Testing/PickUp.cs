using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{

    public Transform owner = null;
    public bool grabbed = false;
    public float holdDistance = 4.0f;

    public float collisionOffset = 0;
    public bool resumeCollision = false;

    private Vector3 initialScale;

    
    
    public float yPos = 0;

    // Start is called before the first frame update
    void Start()
    {
        //NOBODY OWNS ME!!!
        owner = null;
        initialScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()

    {

        return;

        //if I have an owner
        if (owner)
        {


            if (grabbed == false)
            {
                transform.GetComponent<Rigidbody>().isKinematic = true;
                transform.GetComponent<MeshCollider>().enabled = false;
                transform.localPosition = new Vector3(0, 0, 0); //reset to center of parent space
                transform.localScale *= 0.5f;
                grabbed = true;
            }

            float dist = holdDistance - collisionOffset;
            if (dist < 1.0f)
            {
                dist = 1.0f;
            }
            if (resumeCollision)
            {
                collisionOffset -= 0.1f;
                if (collisionOffset < 0)
                {
                    collisionOffset = 0;
                    resumeCollision = false;
                }

            }

            //set the position:
            Vector3 newpos = owner.position + owner.forward * dist + owner.up;
            transform.parent.position = newpos;

            Vector3 pos = transform.parent.position;
            RaycastHit hit;

            Ray ray = new Ray(pos, -Vector3.up); //make a ray from object to ground

            if (Physics.Raycast(ray, out hit, 100.0f))
            {

                Debug.Log(hit.collider.name);
                yPos = hit.point.y + hit.distance;
                if (yPos < 0.5f)
                {

                    yPos = 0.5f;
                    newpos.y = yPos;
                    transform.parent.position = newpos;

                }

            }
            else
            {
                yPos = 0.5f;
                newpos.y = yPos;
                transform.parent.position = newpos;

            }

    

            
        }

        if (!owner && grabbed)
        {
            grabbed = false;
            transform.localScale = initialScale;
            transform.GetComponent<Rigidbody>().isKinematic = false;
            transform.GetComponent<MeshCollider>().enabled = true;
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag != "Player" && 
            other.tag != "Ground" &&
            other.tag != "ignoreTrigger" &&
            !other.isTrigger      )
        {            
            collisionOffset += 0.1f;
            if (collisionOffset > holdDistance - 1.0f)
                collisionOffset = holdDistance - 1.0f;

            Debug.Log("small sphere collides with " + other.name);

        }



    }



}
