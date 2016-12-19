using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems; 
using System.Collections;

public class StageInfo : MonoBehaviour
{
    public GameObject[] ImageObjects;
    public GameObject button_skip;
    public EventSystem E_system;
    int index = 0;
    // Use this for initialization
    void Start()
    {
        E_system = GameObject.Find("EventSystem").GetComponent<EventSystem>();
        E_system.SetSelectedGameObject(button_skip);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Skip_info()
    {
        if(ImageObjects.Length > index)
        {
            if(ImageObjects[index].activeSelf)
            {
                ImageObjects[index].SetActive(false); 
                index++;
            }
        }
        else
        {
            ImageObjects[index].SetActive(false);
            button_skip.SetActive(false);  
        }
    }
}
