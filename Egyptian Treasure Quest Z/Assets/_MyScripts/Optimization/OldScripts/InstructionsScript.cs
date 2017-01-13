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
    public Button btn_Next;
    public Button btn_Prev;
    public Button btn_Skip;

    
    void Start()
    {
        currentPage = 0;
    }

    
    void Update()
    {
        pages[currentPage].SetActive(true);

        if (currentPage <= minPage) //pag wala na previous page
        {
            btn_Prev.enabled = false;
        }
        else if (currentPage > minPage)
        {
            btn_Prev.enabled = true;
        }

        if (currentPage >= maxPage) //pag wala na next page
        {
            btn_Next.enabled = false;
        }
        else if (currentPage < maxPage)
        {
            btn_Next.enabled = true;
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
        SceneManager.LoadScene(sceneToLoad);
    }
}
