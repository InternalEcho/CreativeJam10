using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginCamSlide : MonoBehaviour {

    public Vector3 initPos;
    public Vector3 finalPos;
    public Transform myCam;
    
	// Use this for initialization
	void Start () 
    {
        initPos = new Vector3(-64.25f, 17.7f, -126.76f);
        finalPos = new Vector3(-49.82f, 17.7f, -126.76f);
        myCam.position = initPos;
        
	}

    void FixedUpdate()
    {
        if (myCam.position.x <= -49.86f)
        {
            myCam.position = Vector3.Lerp(myCam.position, finalPos, 0.8f * Time.deltaTime);
        }
    }
	
}
