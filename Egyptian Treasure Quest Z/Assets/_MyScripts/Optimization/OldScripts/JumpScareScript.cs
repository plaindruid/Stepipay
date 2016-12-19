using UnityEngine;
using System.Collections;

public class JumpScareScript : MonoBehaviour
{
    public bool enable;
    public bool disable;
    public bool destroyable;
    public GameObject[] jumpscares;
    
    
	void Start ()
    {
	
	}
	
	void Update ()
    {
        if (enable)
        {
            disable = false;
        }

        else if (disable)
        {
            enable = false;
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (enable)
            {
                if (destroyable)
                {
                    foreach (GameObject go in jumpscares)
                    {
                        go.SetActive(true);
                        Destroy(go, 5);
                    }
                   
                }
                else
                {
                    foreach (GameObject go in jumpscares)
                    {
                        go.SetActive(true);
                    }
                }
                
            }
            else if (disable)
            {
                if (destroyable)
                {
                    foreach (GameObject go in jumpscares)
                    {
                        go.SetActive(false);
                        Destroy(go, 5);
                    }
                    
                }
                else
                {
                    foreach (GameObject go in jumpscares)
                    {
                        go.SetActive(false);
                    }
                }
                
            }
        }
    }

   
}
