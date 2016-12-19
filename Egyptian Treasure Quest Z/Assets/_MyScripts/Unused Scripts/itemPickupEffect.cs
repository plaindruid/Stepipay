using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class itemPickupEffect : MonoBehaviour
{
    public GameObject tempGM;
    public int points;

    void Update()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        Debug.DrawRay(transform.position, fwd * 10, Color.red);
        if (Input.GetButtonDown("Fire1"))
        {
            if (Physics.Raycast(transform.position, fwd, out hit))
            {
                Debug.Log("may nakita ako");
                if (hit.transform.gameObject.tag == "health")
                {
                    tempGM.GetComponent<GameManager>().playerLife += 10;
                }

                if (hit.transform.gameObject.tag == "coin")
                {
                    tempGM.GetComponent<GameManager>().score += points;
                }
                //Destroy(gameObject);
            }
        }
        



        //RaycastHit hit;
        //if (Physics.Raycast(transform.position, transform.forward, out hit, 100f))
        //{
        //    if (hit.transform.gameObject.tag == "health")
        //    {
        //        tempGM.GetComponent<GameManager>().playerLife += 10;
        //    }

        //    if (hit.transform.gameObject.tag == "trap")
        //    {
        //        tempGM.GetComponent<GameManager>().playerLife -= 15;

        //    }

        //    if (hit.transform.gameObject.tag == "coin")
        //    {
        //        tempGM.GetComponent<GameManager>().score += points;
        //    }
        //    Destroy(gameObject);
        //}
    }



    //void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "Player")
    //    {
    //        tempGM.GetComponent<GameManager>().score += points;
    //        Destroy(gameObject);
    //    }
        
    //}









	//public Stat health1;
	//// Use this for initialization
	//void Awake ()
 //   {
 //       //GameObject.Find("Text").SetActive(true);
	//}
	
	//// Update is called once per frame
	//void Update () {
	
	//}
	//void ChangeHP (float Change)
	//{
	//	health1.CurrentVal = health1.CurrentVal + Change;
	//	if(health1.CurrentVal > 100)
	//	{
	//		health1.CurrentVal = 100;
	//	}
	//	if(health1.CurrentVal == 0)
	//	{
 //           //GameObject.Find("Text").SetActive(true);
	//		print("player has died");
	//	}
	//}
	//void OnTriggerEnter(Collider other)
	//{
	//	RaycastHit hit;
	//	if(Physics.Raycast(transform.position, transform.forward, out hit))
	//	{
	//		if(hit.collider.gameObject.tag == "health")
	//		{
	//			ChangeHP (25);
	//			Destroy(other.gameObject);
	//		}
	//		else if (hit.collider.gameObject.tag == "trap")
	//		{
	//			ChangeHP(-25);
	//		}
	//	}
	//}
}
