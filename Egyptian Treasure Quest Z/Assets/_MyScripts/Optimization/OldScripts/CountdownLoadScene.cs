using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class CountdownLoadScene : MonoBehaviour
{
    public int seconds;
    public int sceneIndex;

    void Start()
    {
        StartCoroutine("Countdown");
    }

    private IEnumerator Countdown()
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(sceneIndex);
    }
}
