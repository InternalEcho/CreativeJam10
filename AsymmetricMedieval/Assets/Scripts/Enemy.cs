using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public GameObject Vision;
	public GameObject Player;

	void move(){
		//rotate first.
		transform.LookAt(Player.transform);
		//move.
		transform.Translate(Vision.GetComponent<Detection>().playerdirection().normalized * Time.deltaTime, Space.World);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Vision.GetComponent<Detection>().canMove){
			move();
		}	
	}
}
