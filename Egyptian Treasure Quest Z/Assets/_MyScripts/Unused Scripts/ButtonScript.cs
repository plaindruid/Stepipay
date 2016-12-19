using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour
{
    public GameObject button;
    public GameObject[] hide;
    
    void Start()
    {

    }
    
    void Update()
    {

    }

    public void back()
    {
        GameObject myEventSystem = GameObject.Find("EventSystem");
        myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(GameObject.Find("btn_Back"));


        foreach (GameObject go in hide)
        {
            go.SetActive(false);
        }
    }
}
