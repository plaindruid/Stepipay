using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

//for loading scene
public class LoadLevel : MonoBehaviour {

    public int level;
    public Transform playerPosition;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //Application.LoadLevel(level);
            SceneManager.LoadScene(level);
            //other.transform.localPosition = playerPosition.localPosition;
        }
    }
}
