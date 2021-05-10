using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectChildRotate : MonoBehaviour
{
    public GameObject target;

    public float rotationSpeed = 10.0f;

    public bool rotateRight = true;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(rotateRight == true)

        {
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);

        }


        if(rotateRight == false)
        {
            transform.Rotate(Vector3.forward * -rotationSpeed * Time.deltaTime);
        }
    }
}
