using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapTrigger : MonoBehaviour {
    public GameObject trap;
    public GameObject trapDeactivator;
    public AudioClip trapSound;
    private AudioSource trapSource;

    // Use this for initialization
    void Start () {
        trapSource = (gameObject.AddComponent<AudioSource>() as AudioSource);
        trapSource.clip = trapSound;
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && trapDeactivator.GetComponent<TrapDeactivator>().trapActivated)
        {
            Debug.Log("trap1 activated");
            trap.GetComponent<Animator>().SetTrigger("ActivateTrap");
            trapSource.Play();
        }
    }
}
