using UnityEngine;
using System.Collections;

public class PortalScript : MonoBehaviour {
    
    public GameObject portalDestination;


    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            col.transform.position = portalDestination.transform.position;
        }
    }
}
