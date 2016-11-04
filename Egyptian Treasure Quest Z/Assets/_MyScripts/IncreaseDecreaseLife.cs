using UnityEngine;
using System.Collections;

public class IncreaseDecreaseLife : MonoBehaviour
{
    public int points;
    public bool increaseLife;
    public bool decreaseLife;
    public GameObject tmpGM;

    void Start()
    {
        tmpGM = GameObject.FindGameObjectWithTag("GameManager");
    }

    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (increaseLife)
            {
                tmpGM.GetComponent<GameManager>().playerLife += points;
            }

            if (decreaseLife)
            {
                tmpGM.GetComponent<GameManager>().playerLife -= points;
            }
        }
    }
}
