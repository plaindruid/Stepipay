using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ArtifactManager : MonoBehaviour
{
    public int collected_artifacts;
    public GameObject[] artifacts;
    public Transform[] holders;
    public bool artifacts_completed;
    public GameObject[] hide;
    public GameObject[] show;
    public GameObject[] destroy;
    public GameObject[] doorUnlocked;
    public Animator tomb_Open;
    public GameObject itemstxt;
    public GameObject key;
    public bool key_aqquired;


    void Update()
    {
        itemstxt.GetComponent<Text>().text = collected_artifacts.ToString();

        if (artifacts_completed)
        {
            GameObject.Find("instructions").GetComponent<TextMesh>().text = "Completed. The tomb is open.";
            foreach (GameObject art in artifacts)
            {
                art.SetActive(true);
                //art.GetComponent<MeshRenderer>().enabled = true;
            }
            placeArtifactOnHolder();

            foreach (GameObject go in hide)
            {
                go.SetActive(false);
            }

            foreach (GameObject go in show)
            {
                go.SetActive(true);
            }

            foreach (GameObject go in destroy)
            {
                Destroy(go);
            }

            Open_Tomb();

        }
        else
        {
            

        }

        if (key_aqquired)
        {
            foreach (GameObject go in doorUnlocked)
            {
                go.SetActive(false);
            }

        }
    }

    void placeArtifactOnHolder()
    {
        artifacts[0].transform.position = holders[0].position;
        artifacts[1].transform.position = holders[1].position;
        artifacts[2].transform.position = holders[2].position;
    }

    void Open_Tomb()
    {
        tomb_Open.SetBool("isLocked", false);
    }
}
