using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;
using UnityStandardAssets.Characters.FirstPerson;

public class StorylineScript : MonoBehaviour
{
    public GameObject bg;
    public GameObject sp1;
    public GameObject sp2;
    public GameObject sp3;
    public GameObject sp4;
    public GameObject sp5;
    public GameObject btnSkip;
    GameObject player;
    public GameObject[] pages;

    void Start()
    {
        bg.SetActive(false);
        sp1.SetActive(false);
        sp2.SetActive(false);
        sp3.SetActive(false);
        sp4.SetActive(false);
        sp5.SetActive(false);
        btnSkip.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player");

        StartCoroutine(storyTelling());
    }
    
    void Update()
    {

    }

    IEnumerator storyTelling()
    {
        yield return new WaitForSeconds(2);
        player.GetComponent<FirstPersonController>().enabled = false;
        sp1.SetActive(true);
        btnSkip.SetActive(true);
        bg.SetActive(true);
        GameObject myEventSystem = GameObject.Find("EventSystem");
        myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(GameObject.Find("btn_Skip"));

        yield return new WaitForSeconds(10);
        sp1.SetActive(false);
        sp2.SetActive(true);

        yield return new WaitForSeconds(8);
        sp2.SetActive(false);
        sp3.SetActive(true);

        yield return new WaitForSeconds(5);
        sp4.SetActive(true);

        yield return new WaitForSeconds(5);
        sp5.SetActive(true);

        yield return new WaitForSeconds(2);
        sp3.SetActive(false);
        sp4.SetActive(false);
        sp5.SetActive(false);
        bg.SetActive(false);
        btnSkip.SetActive(false);
        player.GetComponent<FirstPersonController>().enabled = true;
        foreach (GameObject pg in pages)
        {
            Destroy(pg);
        }
    }

    public void pressSkip()
    {
        //StopAllCoroutines();
        //sp1.SetActive(false);
        //sp2.SetActive(false);
        //sp3.SetActive(false);
        //sp4.SetActive(false);
        //sp5.SetActive(false);
        //btnSkip.SetActive(false);
        //bg.SetActive(false);
        //player.GetComponent<FirstPersonController>().enabled = true;

        StopAllCoroutines();
        player.GetComponent<FirstPersonController>().enabled = true;
        foreach (GameObject pg in pages)
        {
            Destroy(pg);
        }

    }

    
}
