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
}
