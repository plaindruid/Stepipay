using UnityEngine;
using System.Collections;

public class waterDamage : MonoBehaviour {

    // Use this for initialization
    public GameObject tempGM;

    void Awake()
    {
        tempGM = GameObject.FindGameObjectWithTag("GameManager");
    }
    

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "MainCamera")
        {
            Debug.Log("nalunod si player");
            tempGM.GetComponent<GameManager>().playerLife -= 5;
        }
    }
}
