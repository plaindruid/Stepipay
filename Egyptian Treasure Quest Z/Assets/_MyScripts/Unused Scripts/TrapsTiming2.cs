using UnityEngine;
using System.Collections;

public class TrapsTiming2 : MonoBehaviour {
	public float trapsduration = 2f;
	public GameObject SpikesCollider;
	private float originalduration;
	// Use this for initialization
	void Start () {
		SpikesCollider.SetActive (true);
		originalduration = trapsduration;
	}
	
	// Update is called once per frame
	void Update () {
		trapsduration -= Time.deltaTime;
		if(trapsduration <= -0.8){
			SpikesCollider.SetActive (false);
			trapsduration = originalduration;
		}
		else if(trapsduration <= 1){
			SpikesCollider.SetActive (true);

		}


	}
}
