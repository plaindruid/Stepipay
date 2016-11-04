using UnityEngine;
using System.Collections;

public class Coroutine : MonoBehaviour
{
    public GameObject[] objects;
    public bool hide;
    public bool show;
    public bool destroy;
    public int seconds;



    void Start()
    {

    }
    
    void Update()
    {
        if (hide)
        {
            StartCoroutine(hideObj());
        }
        else if (show)
        {
            StartCoroutine(showObj());
        }
        else if (destroy)
        {
            StartCoroutine(destroyObj());
        }
        
    }

    IEnumerator hideObj()
    {
        yield return new WaitForSeconds(seconds);
        foreach (GameObject obj in objects)
        {
            obj.SetActive(false);
        }
    }

    IEnumerator showObj()
    {
        yield return new WaitForSeconds(seconds);
        foreach (GameObject obj in objects)
        {
            obj.SetActive(true);
        }
    }

    IEnumerator destroyObj()
    {
        yield return new WaitForSeconds(seconds);
        foreach (GameObject obj in objects)
        {
            Destroy(obj);
        }
    }



}
