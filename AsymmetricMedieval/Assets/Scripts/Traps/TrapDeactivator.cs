using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDeactivator : MonoBehaviour {
    public bool trapActivated;
    public GameObject trap;
    public Color color;
    public Color highlightColor;
	// Use this for initialization
	void Start () {
        trapActivated = true;
        color = this.GetComponent<Renderer>().material.color;
	}
	
	// Update is called once per frame
	void Update () {
        //trap.GetComponent<Animator>().SetTrigger("ActivateTrap");
        this.GetComponent<Renderer>().material.color = color;
    }

    public void highlight()
    {
        if(trapActivated)
            this.GetComponent<Renderer>().material.color = highlightColor;
    }

    public void disableTrap()
    {
        Debug.Log("trap deactivated");
        trapActivated = false;
        this.GetComponent<Animator>().SetTrigger("PullLever");
        StartCoroutine(leverSound());
    }

    IEnumerator leverSound()
    {
        yield return new WaitForSeconds(0.2f);
        this.GetComponent<AudioSource>().Play();
    }
}
