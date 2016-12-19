using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class menuScript : MonoBehaviour
{
    public GameObject quitMenu;
    //public string coroutine;

    void Start()
    {
        quitMenu.SetActive(false);
    }
    

    //play button
    public void StartLevel()
    {
        StartCoroutine(play());
    }

    IEnumerator play()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Lobby");
    }
    






    //help button
    public void HelpPress()
    {
        StartCoroutine(help());
    }

    IEnumerator help()
    {
        yield return new WaitForSeconds(2);
        Debug.Log("Help is clicked.");
    }






    //settings button
    public void SettingsPress()
    {
        StartCoroutine(settings());
    }

    IEnumerator settings()
    {
        yield return new WaitForSeconds(2);
        Debug.Log("Settings is clicked.");
    }






    //quit button
    public void ExitPress()
    {
        StartCoroutine(exit());
    }

    IEnumerator exit()
    {
        yield return new WaitForSeconds(2);
        quitMenu.SetActive(true);
    }






    //no button
    public void NoPress()
    {
        StartCoroutine(no());
    }

    IEnumerator no()
    {
        yield return new WaitForSeconds(2);
        quitMenu.SetActive(false);
    }






    //yes button
    public void YesPress()
    {
        StartCoroutine(yes());
    }

    IEnumerator yes()
    {
        yield return new WaitForSeconds(2);
        Application.Quit();
    }







    //back to main menu scene
    public void mainMenu()
    {
        SceneManager.LoadScene("Menu");
        
    }
}
	
