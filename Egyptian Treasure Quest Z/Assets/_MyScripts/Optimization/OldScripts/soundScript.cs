using UnityEngine;
using System.Collections;

public class soundScript : MonoBehaviour
{
    public AudioSource audio;
    
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            audio.Play();
        }
    }
}
