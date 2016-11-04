using UnityEngine;
using System.Collections;

public class moneyBehavior : MonoBehaviour
{
    public bool gotMoney;
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
        
    }

    
}
