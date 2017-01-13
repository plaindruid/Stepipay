using UnityEngine;
using System.Collections;

public class RayCastSteph : MonoBehaviour
{
    public GameObject HandIndicator;

   
       
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Vector3 forwardCenter = transform.TransformDirection(Vector3.forward);
        Debug.DrawRay(transform.position, forwardCenter * 5, Color.red);

        int layer_mask = LayerMask.GetMask("Item", "ItemReciever");

        if (!StephGameManager.instance.IsPaused)
        {
            if (Physics.Raycast(transform.position, forwardCenter, out hit, 5f, layer_mask))
            {

                Debug.Log(hit.transform.name);
                if (hit.transform.GetComponent<ItemScript>())
                {
                    //Debug.Log("wee1");
                    if (HandIndicator != null)
                    {
                        HandIndicator.SetActive(true);
                    }
                    if (Input.GetMouseButtonUp(0) || Input.GetKeyUp(KeyCode.E) || Input.GetButtonDown("Fire1"))// Dito maglalagay ng button or key nagagamitin para kumuha ng object
                    {
                        hit.transform.GetComponent<ItemScript>().Obtained = true;
                    }
                }

                else if (hit.transform.GetComponent<ItemReciever>())
                {
                    //Debug.Log("wee2");
                    if (HandIndicator != null)
                    {
                        HandIndicator.SetActive(true);
                    }
                    if (Input.GetMouseButtonUp(0) || Input.GetKeyUp(KeyCode.E) || Input.GetButtonDown("Fire1")) // Dito maglalagay ng button or key nagagamitin para Ilagay yung object sa reciever
                    {
                        hit.transform.GetComponent<ItemReciever>().TestRequired = true;
                    }
                }
                else
                {
                    //Debug.Log("wee3");
                    if (HandIndicator != null)
                    {
                        HandIndicator.SetActive(false);
                    }
                }
            }
            else
            {
                //Debug.Log("wee3");
                if (HandIndicator != null)
                {
                    HandIndicator.SetActive(false);
                }
            }
        }
    }
}
