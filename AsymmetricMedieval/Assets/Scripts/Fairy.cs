using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fairy : MonoBehaviour {

    public GameObject player;

	// Use this for initialization
	void Start () {
		
	}
    
    // Update is called once per frame
    void Update () {
        turnToMouse();
        move();
    }

    void move()
    {
        Vector3 temp = Input.mousePosition;
        temp.z = 2f;
        this.transform.position = Camera.main.ScreenToWorldPoint(temp);
    }

    void turnToMouse()
    {
        Vector3 position = transform.position;
        position += player.transform.forward * 30;

        Plane ground = new Plane(player.transform.forward, position);
        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        float rayLength;
        if (ground.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            transform.LookAt(pointToLook);
        }
        //Debug.DrawLine(cameraRay.origin, cameraRay.GetPoint(rayLength), Color.black);
    }
}
