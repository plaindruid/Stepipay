using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenuScript : MonoBehaviour
{
    public GameObject goHome;
    public GameObject goAbout;
    public GameObject goHelp;
    public GameObject goSettings;
    public GameObject goQuit;
    public GameObject goBack;
    public bool musicOn;
    GameObject[] sounds; 


    void Start ()
    {
        GameObject myEventSystem = GameObject.Find("EventSystem");
        myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(GameObject.Find("btn_Start"));
        sounds = GameObject.FindGameObjectsWithTag("AudioSource");
    }

    
	

    public void pressStart()
    {
        SceneManager.LoadScene("Levels");
    }

    public void pressAbout()
    {
        goAbout.SetActive(true);
        goBack.SetActive(true);
        goHelp.SetActive(false);
        goSettings.SetActive(false);
        goQuit.SetActive(false);
        goHome.SetActive(false);
        GameObject myEventSystem = GameObject.Find("EventSystem");
        myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(GameObject.Find("btn_Back"));
    }

    public void pressHelp()
    {
        goHelp.SetActive(true);
        goBack.SetActive(true);
        goAbout.SetActive(false);
        goSettings.SetActive(false);
        goQuit.SetActive(false);
        goHome.SetActive(false);
        GameObject myEventSystem = GameObject.Find("EventSystem");
        myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(GameObject.Find("btn_Back"));
    }

    public void pressSettings()
    {
        goSettings.SetActive(true);
        goBack.SetActive(true);
        goHelp.SetActive(false);
        goAbout.SetActive(false);
        goQuit.SetActive(false);
        goHome.SetActive(false);
        GameObject myEventSystem = GameObject.Find("EventSystem");
        myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(GameObject.Find("btn_Back"));
    }

    public void pressQuit()
    {
        goQuit.SetActive(true);
        goHelp.SetActive(false);
        goSettings.SetActive(false);
        goAbout.SetActive(false);
        goHome.SetActive(false);
        GameObject myEventSystem = GameObject.Find("EventSystem");
        myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(GameObject.Find("btnNo"));
    }

    public void pressYesQuit()
    {
        Application.Quit();
    }
    

    public void pressBack()
    {
        goHome.SetActive(true);
        goBack.SetActive(false);
        goHelp.SetActive(false);
        goSettings.SetActive(false);
        goAbout.SetActive(false);
        goQuit.SetActive(false);
        GameObject myEventSystem = GameObject.Find("EventSystem");
        myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(GameObject.Find("btn_Start"));
    }

    public void musicToggle()
    {   
        musicOn = !musicOn;
        foreach (GameObject audio in sounds)
        {
            audio.SetActive(musicOn);
        }
        
    }

    
}
