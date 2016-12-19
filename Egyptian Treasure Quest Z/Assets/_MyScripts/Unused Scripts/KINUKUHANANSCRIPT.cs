using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class KINUKUHANANSCRIPT : MonoBehaviour {

	public GameObject theplayer;
	public List<GameObject> skulls = new List<GameObject>();
	public GameObject skullGraphics;
	// Use this for initialization
	void Start () {
		skulls.Add (skullGraphics);
		skulls.Add (skullGraphics);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerStay(Collider other){
		if(other.gameObject.tag == "Player"){
			if(Input.GetKeyDown (KeyCode.Space) && skulls.Count > 0){
				theplayer.GetComponent<Inventory>().gotTreasure = true;
			}
		}
	}
}
