using UnityEngine;
using System.Collections;

public class MedkitScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject .tag =="Player"){
			other.gameObject.GetComponent<playerHealth> ().health.CurrentVal += 25;
			Destroy (gameObject);
		}
	
	}

}
