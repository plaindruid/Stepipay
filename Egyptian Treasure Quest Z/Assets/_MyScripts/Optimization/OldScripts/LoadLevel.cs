using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

//for loading scene
public class LoadLevel : MonoBehaviour {

    public string sceneName;

    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
