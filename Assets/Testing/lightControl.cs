using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightControl : MonoBehaviour
{

    public bool isOn = false;
    public float timeDelay = 2.0f;

    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(LightOnOff());
    }

    IEnumerator LightOnOff()
    {
        Debug.Log("Light off at " + Time.deltaTime);  
        
        isOn = true;
        this.gameObject.GetComponent<Light>().enabled = false;
        yield return new WaitForSeconds(timeDelay);

        Debug.Log("Light on at " + Time.deltaTime);

        this.gameObject.GetComponent<Light>().enabled = true;
        yield return new WaitForSeconds(timeDelay);


    }    
}
