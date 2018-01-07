using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public float maxDistance;
	public GameObject player;

	public RaycastHit hit;
	public RaycastHit target;
	public bool canMove;
	public bool seeWallOnce;

	public Vector3 playerdirection(){
		Vector3 direction = player.transform.position - transform.position;
		return direction;
	}

	public void CheckifObstacle(){
		Physics.Raycast(transform.position, playerdirection(), out target, maxDistance);
	}

	public void DetectPlayer(){
		CheckifObstacle ();
		if (target.transform.CompareTag ("Player")) {
			Debug.Log ("work");
			canMove = true;
			seeWallOnce = false;
		} else if (target.collider.gameObject.layer == 8) {
			if(!seeWallOnce)
				StartCoroutine(AttentionSpan ());
			canMove = false;
		}
	}

	IEnumerator AttentionSpan(){
		move ();
		yield return new WaitForSeconds (2.0f);
		seeWallOnce = true;
	}

	void OnDrawGizmos(){
		Gizmos.color = Color.cyan;
		Gizmos.DrawRay (transform.position, playerdirection ());
	}

	void move(){
		//rotate first.
		transform.LookAt(player.transform);
		//move.
		transform.Translate(playerdirection().normalized * Time.deltaTime, Space.World);
	}

	// Use this for initialization
	void Start () {
		seeWallOnce = true;
	}

	// Update is called once per frame
	void Update () {
		DetectPlayer ();
		if(canMove){
			move();
		}	
	}
}
