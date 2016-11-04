using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    static Inventory inventoryInstance;
    public bool gotTreasure = false;
    public float totalTreasure;
    public GameObject treasureTxt;

    void Awake()
    {
        if (inventoryInstance != null)
        {
            Debug.Log("May inventory na");
            GameObject.Destroy(gameObject);
        }
        else
        {
            GameObject.DontDestroyOnLoad(gameObject);
            inventoryInstance = this;
        }
    }

    void Start()
    {
        treasureTxt = GameObject.FindGameObjectWithTag("treasureTxt");
    }

    void Update()
    {
        treasureTxt = GameObject.FindGameObjectWithTag("treasureTxt");
        treasureTxt.GetComponent<Text>().text = totalTreasure.ToString();
    }




    //static Inventory inventoryInstance;
    //public bool gotTreasure = false;
    //GameObject tempGM;
    //public float totalTreasure;
    //public GameObject treasureTxt;

    //void Awake()
    //{
    //    if (inventoryInstance != null)
    //    {
    //        Debug.Log("May inventory na");
    //        GameObject.Destroy(gameObject);
    //    }
    //    else
    //    {
    //        GameObject.DontDestroyOnLoad(gameObject);
    //        inventoryInstance = this;
    //    }
    //}

    //void Start()
    //{
    //    tempGM = GameObject.FindGameObjectWithTag("GameManager");
    //    treasureTxt = GameObject.FindGameObjectWithTag("treasureTxt");
    //}

    //void Update()
    //{
    //    treasureTxt.GetComponent<Text>().text = totalTreasure.ToString();
    //}

    //void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "Player")
    //    {
    //        Debug.Log("ipasa ang pera");
    //        totalTreasure += tempGM.GetComponent<GameManager>().score;
    //        tempGM.GetComponent<GameManager>().score = 0;
    //    }
    //}

}
