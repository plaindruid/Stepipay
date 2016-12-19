using UnityEngine;
using System.Collections;

public class TrapsScript : MonoBehaviour
{
    //public GameObject tempGM;
    GameObject tempGM;
    public int damage;

    void Awake()
    {
        tempGM = GameObject.FindGameObjectWithTag("GameManager");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            tempGM.GetComponent<GameManager>().playerLife -= damage;
        }
        
    }
	
}
