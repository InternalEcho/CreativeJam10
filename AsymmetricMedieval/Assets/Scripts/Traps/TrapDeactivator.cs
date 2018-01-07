using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDeactivator : MonoBehaviour {
    public bool trapActivated;
    public GameObject trap;
	// Use this for initialization
	void Start () {
        trapActivated = true;
	}
	
	// Update is called once per frame
	void Update () {
        //trap.GetComponent<Animator>().SetTrigger("ActivateTrap");
	}

    public void disableTrap()
    {
        Debug.Log("trap deactivated");
        trapActivated = false;
    }
}
