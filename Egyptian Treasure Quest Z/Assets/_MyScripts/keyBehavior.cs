using UnityEngine;
using System.Collections;

public class keyBehavior : MonoBehaviour
{
    public ArtifactManager am;
    public bool gotKey;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(gotKey)
        {
            gameObject.SetActive(false);
            am.key_aqquired = true;
        }
    }
}
