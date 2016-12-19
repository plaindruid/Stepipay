using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PHealth : MonoBehaviour
{

    static PHealth playerInstance;

    void Awake()
    {

        if (playerInstance != null)
        {
            GameObject.Destroy(gameObject);
        }
        else
        {
            GameObject.DontDestroyOnLoad(gameObject);
            playerInstance = this;
        }
    }
    
}




    //void OnTriggerEnter(Collider col)
    //{
    //    //RaycastHit hit;
    //    //if (Physics.Raycast(transform.position, transform.forward, out hit))
    //    //{
    //    //    if (hit.collider.gameObject.tag == "health")
    //    //    {
    //    //        tempPLife += 10;
    //    //        Destroy(col.gameObject);
    //    //    }
    //    //    else if (hit.collider.gameObject.tag == "trap")
    //    //    {
    //    //        tempPLife -= 15;
    //    //    }
    //    //}

    //        //if (col.tag == "health")
    //        //{
    //        //    tempPLife += 10;
    //        //    Destroy(col.gameObject);
    //        //}
    //        //else if (col.tag == "trap")
    //        //{
    //        //    tempPLife -= 15;
    //        //}

    //        tempGM.GetComponent<GameManager>().playerLife = tempPLife;
    //}
