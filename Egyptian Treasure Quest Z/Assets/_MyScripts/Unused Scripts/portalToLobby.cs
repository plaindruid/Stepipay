using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class portalToLobby : MonoBehaviour {
    
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //Application.LoadLevel("Lobby");
            SceneManager.LoadScene("Lobby");
        }
    }
}
