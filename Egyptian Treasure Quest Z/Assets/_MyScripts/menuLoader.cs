using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class menuLoader : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		StartCoroutine ("Countdown");
	}

	private IEnumerator Countdown()
	{
		yield return new WaitForSeconds (4);
        SceneManager.LoadScene(2);
	}
}