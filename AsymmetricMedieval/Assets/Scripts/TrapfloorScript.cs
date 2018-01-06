using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapfloorScript : MonoBehaviour {

    public Transform playerPosition;
    public float activationTime = 0.5f;
    public GameObject trapTrigger;
    public GameObject trapBall;
    
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "Cube")
     //   if (trapTrigger.GetComponent<Trigger>())
        {
            Debug.Log("activate trap!");
            StartCoroutine(ActivateTrap());
        }
    }

    IEnumerator ActivateTrap()
    {
        yield return new WaitForSeconds(activationTime);
        trapBall.GetComponent<Rigidbody>().useGravity = true;
    }

}
