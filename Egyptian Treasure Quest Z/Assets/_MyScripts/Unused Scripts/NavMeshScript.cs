using UnityEngine;
using System.Collections;

public class NavMeshScript : MonoBehaviour {
	public GameObject target;
	NavMeshAgent Agent;
	// Use this for initialization
	void Start () {
		Agent = GetComponent<NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () {
		Agent.SetDestination (target.transform.position);
	}
}