using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class SkipButton : MonoBehaviour
{
    
   
    void Start()
    {

    }

   
    void Update()
    {
        GameObject myEventSystem = GameObject.Find("EventSystem");
        myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(this.gameObject);
    }

    public void pressSkip()
    {
        //SceneManager.LoadScene("Level_Scene");
        LoadingScreenManager.LoadScene(5);
    }
}
