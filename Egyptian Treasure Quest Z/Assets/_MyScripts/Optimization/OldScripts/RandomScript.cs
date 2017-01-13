using UnityEngine;
using System.Collections;

public class RandomScript : MonoBehaviour
{
    public Transform[] item_positions;
    public int random;

    
    void Start()
    {
        int ran = Random.Range(0, random);
        Debug.Log(ran);
        //gameobject.transform = item_positions[ran].transform;
        //this.gameObject.GetComponent<Transform>().transform = item_positions[ran];

        this.gameObject.transform.position = item_positions[ran].position;
        this.gameObject.transform.rotation = item_positions[ran].rotation;
    }

   
    void Update()
    {

    }
}
