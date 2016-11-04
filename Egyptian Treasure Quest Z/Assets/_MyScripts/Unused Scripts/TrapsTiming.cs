using UnityEngine;
using System.Collections;

public class TrapsTiming : MonoBehaviour {

	void OnTriggerEnter(Collider other)
    {
	    if(other.gameObject .tag == "Player")
        {
			other.gameObject.GetComponent<playerHealth> ().health.CurrentVal -= 5;
		}
	}
}
