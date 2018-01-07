using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerVictory : MonoBehaviour {

	
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            StartCoroutine(GameManagementScript.Instance.WinnerChickenDinner());
        }
    }

}
