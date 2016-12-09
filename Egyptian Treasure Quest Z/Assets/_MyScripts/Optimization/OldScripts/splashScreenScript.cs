using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class splashScreenScript : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		StartCoroutine ("Countdown");
	}
	
	private IEnumerator Countdown()
	{
		yield return new WaitForSeconds (4);
        //Application.LoadLevel(1);
        SceneManager.LoadScene(1);
	}
}
