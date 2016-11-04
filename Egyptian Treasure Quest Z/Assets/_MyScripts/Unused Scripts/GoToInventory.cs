using UnityEngine;
using System.Collections;

public class GoToInventory : MonoBehaviour
{
    GameObject camelInventory;
    GameObject tempGM;
    public float tempTreasure;

    void Awake()
    {
        camelInventory = GameObject.FindGameObjectWithTag("Inventory");
        tempGM = GameObject.FindGameObjectWithTag("GameManager");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            tempTreasure = tempGM.GetComponent<GameManager>().score;
            tempGM.GetComponent<GameManager>().score = 0;
            camelInventory.GetComponent<Inventory>().totalTreasure += tempTreasure;
            tempTreasure = 0;
        }
    }

}

	
