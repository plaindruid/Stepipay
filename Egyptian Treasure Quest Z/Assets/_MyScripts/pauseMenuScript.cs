using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class pauseMenuScript : MonoBehaviour
{
    public GameObject goPauseMenu;
    public bool isPaused = false;
    GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            goPauseMenu.SetActive(isPaused);

            if (isPaused)
            {
                Time.timeScale = 0;
                player.GetComponent<FirstPersonController>().enabled = false;
                GameObject myEventSystem = GameObject.Find("EventSystem");
                myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(GameObject.Find("btn_Resume"));
            }
            else
            {
                Time.timeScale = 1;
                player.GetComponent<FirstPersonController>().enabled = true;
            }
        }
    }
    

    public void pressResume()
    {
        Time.timeScale = 1;
        player.GetComponent<FirstPersonController>().enabled = true;
        isPaused = !isPaused;
        goPauseMenu.SetActive(isPaused);
    }

    public void pressMainMenu()
    {
        Time.timeScale = 1;
        player.GetComponent<FirstPersonController>().enabled = true;
        SceneManager.LoadScene("Menu");
    }
}
