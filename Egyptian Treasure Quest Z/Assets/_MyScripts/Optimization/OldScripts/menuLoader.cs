using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class menuLoader : MonoBehaviour {

    public int seconds;
    public string sceneName;

	
	void Start () 
	{
		StartCoroutine ("Countdown");
	}

	private IEnumerator Countdown()
	{
		yield return new WaitForSeconds (seconds);
        SceneManager.LoadScene(sceneName);
	}
}