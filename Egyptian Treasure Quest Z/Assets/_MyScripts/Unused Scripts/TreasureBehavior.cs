using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TreasureBehavior : MonoBehaviour {
	public GameObject theplayer;

	public List<GameObject> Treasures = new List<GameObject>();

	public GameObject kinukuhananGO;
	// Use this for initialization
	void Start () {
	//	Basta = kinukuhananGO.GetComponent<KINUKUHANANSCRIPT> ().skulls[];
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerStay(Collider other){
		if(other.gameObject.tag == "Player"){
			if(Input.GetKeyDown (KeyCode.Space)){
				if(theplayer.GetComponent<Inventory>().gotTreasure == true){
					Treasures.Add (kinukuhananGO.GetComponent<KINUKUHANANSCRIPT> ().skulls[0]);
					kinukuhananGO.GetComponent<KINUKUHANANSCRIPT> ().skulls.RemoveAt(0);
					//Basta.RemoveAt(0);
					theplayer.GetComponent<Inventory>().gotTreasure = false;
				}
			
			}
		}
	}
}
