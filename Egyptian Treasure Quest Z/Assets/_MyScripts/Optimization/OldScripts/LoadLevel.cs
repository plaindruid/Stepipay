using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

//for loading scene
public class LoadLevel : MonoBehaviour {

    public int level;
    public Transform playerPosition;
    public GameObject timer;

    void Update()
    {
        timer = GameObject.FindGameObjectWithTag("timer");

        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (timer != null)
            {
                timer.GetComponent<TimerScript>().stopTimer = true;
            }
            
            SceneManager.LoadScene(level);
            other.transform.localPosition = playerPosition.localPosition;
        }
    }
}
