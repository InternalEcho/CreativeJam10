using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fairy : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 temp = Input.mousePosition;
        temp.z = 2f; // Set this to be the distance you want the object to be placed in front of the camera.
        this.transform.position = Camera.main.ScreenToWorldPoint(temp);
    }
}
