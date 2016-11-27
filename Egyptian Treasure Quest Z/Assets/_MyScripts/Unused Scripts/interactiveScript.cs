using UnityEngine;

public class interactiveScript : MonoBehaviour
{

    GameObject mainCam;
	public float interactDistance = 8f;
    public GameObject icon;
    int interactables;
    GameObject collected;
    GameObject tempGM;
    public AudioSource coin_sound;

    void Awake()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera");
        tempGM = GameObject.FindGameObjectWithTag("GameManager");
        
    }
    void Update ()
    {
        int x = Screen.width / 2;
        int y = Screen.height / 2;
        Ray ray = mainCam.GetComponent<Camera>().ScreenPointToRay(new Vector3(x, y));
        RaycastHit hit;

        //RaycastHit hit;
        //Vector3 forwardCenter = transform.TransformDirection(Vector3.forward);
        //Debug.DrawRay(transform.position, forwardCenter * 500, Color.red);
        //if (Physics.Raycast(transform.position, forwardCenter, out hit, 500f))

        if (Physics.Raycast(ray, out hit, interactDistance))
        {
            if (hit.collider.CompareTag("Artifact"))
            {
                icon.SetActive(true);
                interactables = 1;
            }
            else if (hit.collider.CompareTag("money"))
            {
                icon.SetActive(true);
                interactables = 2;
            }
            else if (hit.collider.CompareTag("key"))
            {
                icon.SetActive(true);
                interactables = 3;
            }
            else
            {
                icon.SetActive(false);
            }
        }




        if (Input.GetButtonDown("Fire1"))
        {
            if (interactables == 1) //artifact
            {
                collected = hit.collider.gameObject;
                collected.GetComponent<ArtifactBehavior>().HawakNiPlayer = true;

            }
            else if (interactables == 2)
            {
                hit.collider.gameObject.GetComponent<pickUpScript>().gotMoney = true;
                coin_sound.Play();
            }
            else if (interactables == 3)
            {
                hit.collider.gameObject.GetComponent<keyBehavior>().gotKey = true;
                coin_sound.Play();
            }

        }


    }
    
}