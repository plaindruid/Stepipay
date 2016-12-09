using UnityEngine;
using System.Collections;

public class SceneLoader : MonoBehaviour {

	public string SceneName;

	public enum Activation_type
	{
		Trigger,
		Script
	}

	public Activation_type ActivationType;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Player") 
		{
			UnityEngine.SceneManagement.SceneManager.LoadScene (SceneName);
		}
				
	}

}
