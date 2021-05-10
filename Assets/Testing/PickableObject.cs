using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObject : MonoBehaviour
{

    public bool isPicked;
    public bool isHovered;
    public Transform owner;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (isHovered)
        { 
            Debug.Log("isHovered"); 
        }    

        if(owner)
        {
            
        }


    }
}
