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
	public Animator animator;

	public float jumpDistance;
	public bool inDamageRange;

	public int health;
	public int healthIncrement;
	public bool hasDied;

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
			//Debug.Log ("work");
			if (Vector3.SqrMagnitude (player.transform.position - transform.position) < jumpDistance) {
				inDamageRange = true;
				canMove = false;
			} else {
				inDamageRange = false;
				canMove = true;
			}
			seeWallOnce = false;
		} else if (target.collider.gameObject.layer == 8) {
			canMove = false;
		}
	}

	void OnDrawGizmos(){
		Gizmos.color = Color.cyan;
		Gizmos.DrawRay (transform.position, playerdirection ());
	}

	void move(){
		//rotate first.
		transform.LookAt(player.transform);
		//move.
		transform.Translate(Vector3.Project(playerdirection().normalized, transform.forward) * Time.deltaTime, Space.World);

	}
		
	void damagePlayer(){
		//player.GetComponent<Player> ().loseHp ();
	}

	public void loseHP(){
		health -= healthIncrement;
	}

	public void checkHP(){
		if(health <= 0){
			hasDied = true;
			Object.Destroy(this.gameObject, 5.0f);
			//Instantiate(
		}
	}

	// Use this for initialization
	void Start () {
		seeWallOnce = true;
		inDamageRange = false;
		hasDied = false;
	}

	// Update is called once per frame
	void Update () {

		checkHP ();
		DetectPlayer ();
		if(canMove){
			move();
		}
		animate ();
	}

	void animate(){
		animator.SetBool("walk", canMove);
		animator.SetBool("jump", inDamageRange);
		animator.SetBool ("die", hasDied);
	}
}
