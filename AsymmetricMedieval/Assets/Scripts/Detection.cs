using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection : MonoBehaviour {

	public bool inRange;

	public getInRange(){
		return inRange;
	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "Player")
			
	}

	// Use this for initialization
	void Start () {
		inRange = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
