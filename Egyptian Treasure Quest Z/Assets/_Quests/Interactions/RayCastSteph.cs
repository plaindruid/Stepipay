using UnityEngine;
using System.Collections;

public class RayCastSteph : MonoBehaviour
{
    public GameObject HandIndicator;
    int interactables;
    public AudioSource coin_sound;

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

        if (Physics.Raycast(transform.position, forwardCenter, out hit, 5f))
        {


            if (hit.transform.GetComponent<ItemScript>())
            {
                if (HandIndicator != null)
                {
                    HandIndicator.SetActive(true);
                }


                if (Input.GetMouseButtonUp(0) || Input.GetKeyUp(KeyCode.E))
                {
                    hit.transform.GetComponent<ItemScript>().Obtained = true;
                }
            }


            else if (hit.transform.GetComponent<ItemReciever>())
            {
                if (HandIndicator != null)
                {
                    HandIndicator.SetActive(true);
                }


                if (Input.GetMouseButtonUp(0) || Input.GetKeyUp(KeyCode.E))
                {
                    hit.transform.GetComponent<ItemReciever>().TestRequired = true;
                }
            }

            else if (hit.collider.CompareTag("money"))
            {
                HandIndicator.SetActive(true);
                if (Input.GetMouseButtonUp(0) || Input.GetKeyUp(KeyCode.E))
                {
                    hit.collider.gameObject.GetComponent<pickUpScript>().gotMoney = true;
                    coin_sound.Play();
                }
            }
            else if (hit.collider.CompareTag("potion"))
            {
                HandIndicator.SetActive(true);
                if (Input.GetMouseButtonUp(0) || Input.GetKeyUp(KeyCode.E))
                {
                    hit.collider.gameObject.GetComponent<pickUpScript>().gotPotion = true;
                    coin_sound.Play();
                }
            }
            else if (hit.collider.CompareTag("key"))
            {
                HandIndicator.SetActive(true);
                if (Input.GetMouseButtonUp(0) || Input.GetKeyUp(KeyCode.E))
                {
                    hit.transform.GetComponent<ItemScript>().Obtained = true;
                    coin_sound.Play();
                }
            }
            

            else
            {
                if (HandIndicator != null)
                {
                    HandIndicator.SetActive(false);
                }
            }

        }
    }
}
