using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public float maxDistance;
    public float enemySpeed;
	public GameObject player;

	public RaycastHit hit;
	public RaycastHit target;
	public bool canMove;
	public bool seeWallOnce;
	public Animator animator;

	public float jumpDistance;
	public bool inDamageRange;

	public Vector3 playerdirection(){
		Vector3 direction = player.transform.position - transform.position;
		return direction;
	}

	public void CheckifObstacle(){
		Physics.Raycast(transform.position + this.transform.forward * 5, playerdirection(), out target, maxDistance);
	}

	public void DetectPlayer(){
		CheckifObstacle ();
        //Debug.Log(target.transform.name);
		if (target.transform.CompareTag ("Player") && !canMove) {
			Debug.Log ("work");
            this.GetComponent<AudioSource>().Play();
            this.GetComponent<Animator>().SetBool("CanMove", true);
			canMove = true;
			if (Vector3.SqrMagnitude (player.transform.position - transform.position) < jumpDistance) {
				inDamageRange = true;
				canMove = false;
			} else {
				inDamageRange = false;
				canMove = true;
			}
			seeWallOnce = false;
		} else if (target.collider.gameObject.layer == 8) {
			if(!seeWallOnce)
				StartCoroutine(AttentionSpan ());
			canMove = false;
		}
	}

	IEnumerator AttentionSpan(){
		canMove = true;
		yield return new WaitForSeconds (2.0f);
		seeWallOnce = true;
	}

	void OnDrawGizmos(){
		Gizmos.color = Color.cyan;
		Gizmos.DrawRay (transform.position + this.transform.forward * 5, transform.forward);
	}

	void move(){
		//rotate first.
		transform.LookAt(player.transform);

        //move.
        Vector3 direction = playerdirection();
        direction.y = 0;
		transform.Translate(direction.normalized * enemySpeed, Space.World);

	}

	// Use this for initialization
	void Start () {
		seeWallOnce = true;
		inDamageRange = false;
	}

	// Update is called once per frame
	void Update () {


		DetectPlayer ();
		if(canMove){
			move();
		}
		animate ();
	}

	void animate(){
		animator.SetBool("walk", canMove);
		animator.SetBool("jump", inDamageRange);
		//animator.SetBool ("die", hasDied);
	}
}
