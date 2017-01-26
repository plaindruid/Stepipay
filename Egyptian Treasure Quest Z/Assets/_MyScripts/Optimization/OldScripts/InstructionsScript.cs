using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class InstructionsScript : MonoBehaviour
{
    public GameObject[] pages;
    public int currentPage;
    public int minPage;
    public int maxPage;
    public string sceneToLoad;
    public int sceneIndex;
    public GameObject btn_Next;
    public GameObject btn_Prev;
    public GameObject btn_Skip;

    
    void Start()
    {
        currentPage = 0;
        GameObject.Find("EventSystem").GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(GameObject.Find("btn_Skip"));
    }

    
    void Update()
    {
        pages[currentPage].SetActive(true);

        if (currentPage <= minPage) //pag wala na previous page
        {
            btn_Prev.SetActive(false);
            GameObject.Find("EventSystem").GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(GameObject.Find("btn_Next"));
            
        }
        else if (currentPage > minPage)
        {
            btn_Prev.SetActive(true);
        }

        if (currentPage >= maxPage) //pag wala na next page
        {
            btn_Next.SetActive(false);
            GameObject.Find("EventSystem").GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(GameObject.Find("btn_Skip"));
            
        }
        else if (currentPage < maxPage)
        {
            btn_Next.SetActive(true);
        }

        if (Input.GetButtonDown("Fire2") || Input.GetButtonDown("Fire3") || Input.GetButtonDown("Jump"))
        {
            GameObject.Find("EventSystem").GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(GameObject.Find("btn_Skip"));
        }


    }

    public void click_Next()
    {
        currentPage += 1;
        pages[currentPage - 1].SetActive(false);
    }

    public void click_Previous()
    {
        currentPage -= 1;
        pages[currentPage + 1].SetActive(false);
    }

    public void click_Skip()
    {
        //SceneManager.LoadScene(sceneToLoad);
        LoadingScreenManager.LoadScene(sceneIndex);
    }
}
