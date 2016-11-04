using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PickUpItem : MonoBehaviour {

    public GameObject tempGM;
    public int points;

    //void Update()
    //{
    //    RaycastHit hit;
    //    if (Physics.Raycast(transform.position, transform.forward, out hit, 100f))
    //    {
    //        if (hit.transform.gameObject.tag == "health")
    //        {
    //            tempGM.GetComponent<GameManager>().playerLife += 10;
    //        }

    //        if (hit.transform.gameObject.tag == "trap")
    //        {
    //            tempGM.GetComponent<GameManager>().playerLife -= 15;

    //        }

    //        if (hit.transform.gameObject.tag == "coin")
    //        {
    //            tempGM.GetComponent<GameManager>().score += points;
    //        }
    //        Destroy(gameObject);
    //    }
    //}

    //void FixedUpdate()
    //{
    //    Vector3 fwd = transform.TransformDirection(Vector3.forward);

    //    if (Physics.Raycast(transform.position, fwd, 10))
    //        print("There is something in front of the object!");
    //}

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, 100))
            Debug.Log("Hit something!");
    }
}
