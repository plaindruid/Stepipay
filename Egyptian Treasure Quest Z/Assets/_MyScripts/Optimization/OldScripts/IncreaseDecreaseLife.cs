using UnityEngine;
using System.Collections;

public class IncreaseDecreaseLife : MonoBehaviour
{
    public int points;
    public bool increaseLife;
    public bool decreaseLife;
    public AudioSource audio;
    GameObject tmpGM;
    bool activated;

    void Start()
    {
        tmpGM = GameObject.FindGameObjectWithTag("GameManager");
        activated = false;
    }

    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            activated = true;
            if (audio != null)
            {
                audio.Play();
            }

            if (activated)
            {
                if (increaseLife)
                {
                    tmpGM.GetComponent<GameManager>().playerLife += points;
                    activated = false;
                }

                if (decreaseLife)
                {
                    tmpGM.GetComponent<GameManager>().playerLife -= points;
                    activated = false;
                }
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            activated = false;
            
        }
    }
}
