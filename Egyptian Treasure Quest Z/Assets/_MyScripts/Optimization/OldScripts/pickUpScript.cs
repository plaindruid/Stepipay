using UnityEngine;
using System.Collections;

public class pickUpScript : MonoBehaviour
{
    public bool gotMoney;
    public bool gotPotion;
    public float value;
    GameObject tempGM;

    void Start()
    {
        tempGM = GameObject.FindGameObjectWithTag("GameManager");
    }
    
    void Update()
    {
        if (gotMoney)
        {
            tempGM.GetComponent<GameManager>().score += value;
            Destroy(gameObject);
        }

        if (gotPotion)
        {
            tempGM.GetComponent<GameManager>().playerLife += value;
            Destroy(gameObject);
        }
        
    }

    
}
