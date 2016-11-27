using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class ArtifactBehavior : MonoBehaviour
{
    public ArtifactManager am;
    public bool HawakNiPlayer;
    public GameObject artifact;
    public GameObject trivia;
    GameObject player;
    public GameObject btn_Close;
    public GameObject mesh;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (HawakNiPlayer) //hawak
        {
            am.collected_artifacts += 1;
            HawakNiPlayer = false;
            //artifact.GetComponent<MeshRenderer>().enabled = false;
            mesh.SetActive(false);
            trivia.SetActive(true);

            GameObject myEventSystem = GameObject.Find("EventSystem");
            myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(GameObject.Find("btn_Close"));

            Time.timeScale = 0;
            player.GetComponent<FirstPersonController>().enabled = false;
            
        }
    }

    public void pressClose()
    {
        trivia.SetActive(false);
        Time.timeScale = 1;
        player.GetComponent<FirstPersonController>().enabled = true;
    }
    
   
    
}
