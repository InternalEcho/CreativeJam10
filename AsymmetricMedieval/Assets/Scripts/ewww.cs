using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ewww : MonoBehaviour {

	public float maxDistance = 100.0f;
	public GameObject Enemy;

	Quaternion startingAngle = Quaternion.AngleAxis(-60, Vector3.up);
	Quaternion stepAngle = Quaternion.AngleAxis(5, Vector3.up);

	void DetectThings()
	{
		RaycastHit hit;
		var angle = transform.rotation * startingAngle;
		var direction = angle * Vector3.forward;
		var pos = transform.position;
		for(var i = 0; i < 24; i++)
		{
			if(Physics.Raycast(pos, direction, out hit, 500))
			{
				var enemy = hit.collider.GetComponent<Enemy>();
				if(enemy)
				{
					//Enemy was seen
				}
			}
			direction = stepAngle * direction;
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		DetectThings ();
	}
}
