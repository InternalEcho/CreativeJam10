using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection : MonoBehaviour {

	public float maxDistance;
	public GameObject Enemy;
	public GameObject player;

	public RaycastHit hit;
	public RaycastHit target;
	public bool canMove;

	public Vector3 playerdirection(){
		Vector3 direction = player.transform.position - Enemy.transform.position;
		return direction;
	}

	public void CheckifObstacle(){
		Physics.Raycast(Enemy.transform.position, playerdirection(), out target, maxDistance);
	}

	public void DetectPlayer(){
		CheckifObstacle ();
		if (target.transform.CompareTag ("Player")){
			Debug.Log ("work");
			canMove = true;
		}
//		else if(target.transform.tag == "Environment"){
//			if(hit != target){
//				AttentionSpan()
//			}
//			canMove = false;
//		}
//		hit = target;
	}

	IEnumerator AttentionSpan(){
		Debug.Log (Time.time);
		yield return new WaitForSeconds (5.0f);
		Debug.Log (Time.time);
	}

	void OnDrawGizmos(){
		Gizmos.color = Color.cyan;
		Gizmos.DrawRay (Enemy.transform.position, playerdirection ());
	}

	public bool getConsent(){
		return canMove;
	}

	// Use this for initialization
	void Start () {
		canMove = false;
	}

	
	// Update is called once per frame
	void Update () {
		DetectPlayer ();
	}
}
