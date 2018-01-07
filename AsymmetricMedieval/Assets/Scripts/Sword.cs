using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Stab();
        HorizontalSwing();
	}

    void Stab()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Stabbed");   //Debug
            this.GetComponent<Animator>().SetTrigger("Stab");
        }
    }

    /*void VerticalSwing()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            Debug.Log("Vertical Swing");   //Debug
            this.GetComponent<Animator>().SetTrigger("VerticalSwing");
        }
    }*/

    void HorizontalSwing()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            Debug.Log("Horizontal Swing");   //Debug
            this.GetComponent<Animator>().SetTrigger("HorizontalSwing");
        }
    }

	void OnCollisionEnter(Collision collision){
		foreach (ContactPoint contact in collision.contacts)
		{
			Debug.DrawRay(contact.point, contact.normal, Color.white);
		}
		Debug.Log ("Collision!");
		if (collision.gameObject.CompareTag("Enemy")){
			Debug.Log ("Hit!");
			collision.gameObject.GetComponent<Enemy>().loseHP();
		}
	}
}
