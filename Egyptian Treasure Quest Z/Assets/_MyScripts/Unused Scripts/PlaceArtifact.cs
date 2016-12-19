using UnityEngine;
using System.Collections;

public class PlaceArtifact : MonoBehaviour
{
    public ArtifactManager am;

    void Awake()
    {
        GameObject.Find("instructions").GetComponent<TextMesh>().text = "Find and place items here.";
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && am.collected_artifacts >= 3)
        {
            am.artifacts_completed = true;
        }
        else if (other.tag == "Player" && am.collected_artifacts < 3)
        {
            GameObject.Find("instructions").GetComponent<TextMesh>().text = "Find other items.";
        }
        
    }
}
