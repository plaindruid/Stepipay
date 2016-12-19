using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class ItemBehavior : MonoBehaviour
{
    public ShowInfoScript ss;
    public GameObject trivia;
    GameObject player;
    //public GameObject btn_Close;
    public bool gotItem;
    public int item_id;

    void Start()
    {
        ss = GameObject.Find("forUI").GetComponent<ShowInfoScript>();
        player = GameObject.FindGameObjectWithTag("Player");
        gotItem = false;
    }
    public void pressClose()
    {
        gotItem = false;
        Debug.Log(gotItem);
        trivia.SetActive(false);
        Time.timeScale = 1;
        player.GetComponent<FirstPersonController>().enabled = true;
    }

    void Update()
    {
        if (gotItem)
        {
            ss.q_id = item_id;
            gotItem = false;
            
            //trivia.SetActive(true);
            //gotItem = false;
            //GameObject myEventSystem = GameObject.Find("EventSystem");
            //myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(GameObject.Find("btn_Close"));

            //Time.timeScale = 0;
            //player.GetComponent<FirstPersonController>().enabled = false;

        }
        
    }

    
    
    
   
    
}
