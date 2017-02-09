using UnityEngine;
using System.Collections;

public class Portal_Trigger : MonoBehaviour
{
    public GameObject[] portalParticles;

   
    void Start()
    {

    }

    
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            foreach (GameObject go in portalParticles)
            {
                go.SetActive(true);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            foreach (GameObject go in portalParticles)
            {
                go.SetActive(false);
            }
        }
    }
}
