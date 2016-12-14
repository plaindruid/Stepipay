using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class menuLoader : MonoBehaviour {

    public int seconds;
    public int sceneIndex;

	// Use this for initialization
	void Start () 
	{
		StartCoroutine ("Countdown");
	}

	private IEnumerator Countdown()
	{
		yield return new WaitForSeconds (seconds);
        SceneManager.LoadScene(sceneIndex);
	}
}