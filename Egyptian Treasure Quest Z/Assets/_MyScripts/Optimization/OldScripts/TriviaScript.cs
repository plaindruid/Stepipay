using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class TriviaScript : MonoBehaviour
{
    public GameObject trivia;
    public GameObject btn_ok;
    GameObject player;
    public GameObject itemsDisplay;
    public GameObject btn_Close;

    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        trivia.SetActive(false);
        itemsDisplay.SetActive(false);
    }
    

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            trivia.SetActive(true);
            btn_ok.SetActive(true);
            GameObject myEventSystem = GameObject.Find("EventSystem");
            myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(GameObject.Find("btn_ok"));
            Time.timeScale = 0;
            player.GetComponent<FirstPersonController>().enabled = false;
        }
    }

    public void pressOk()
    {
        trivia.SetActive(false);
        btn_ok.SetActive(false);
        itemsDisplay.SetActive(true);
        btn_Close.SetActive(true);
        GameObject myEventSystem = GameObject.Find("EventSystem");
        myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(GameObject.Find("btn_Close"));
    }

    public void pressClose()
    {
        itemsDisplay.SetActive(false);
        Time.timeScale = 1;
        player.GetComponent<FirstPersonController>().enabled = true;
        Destroy(trivia);
        Destroy(itemsDisplay);
        Destroy(gameObject);
    }

    

    
}
