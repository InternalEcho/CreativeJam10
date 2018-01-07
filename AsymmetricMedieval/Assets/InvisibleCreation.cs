using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleCreation : MonoBehaviour {

    public Transform torch;

	// Use this for initialization
	void Start () {
        transform.position = torch.position;
	}
	
}
