using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{
    public int Stage_ID;
    public Sprite Stage_image;
    public string Stage_name;
    public int sceneIndex;
    bool unlock = false;
    // Use this for initialization
    void Start()
    {
        Stage_image = LevelSelectionManager.steplevelselection.Lock_Sprite;  
    }

    // Update is called once per frame
    void Update()
    {
        Stage_status();
        Change_pic();  
    }

    public void stage_Click()
    {
        if(unlock)
        {
            //SceneManager.LoadScene(Stage_name);  
            LoadingScreenManager.LoadScene(sceneIndex);
        }
    }

    void Stage_status()
    {
        if(Stage_ID != 0 & !unlock)
        {
            unlock = LevelSelectionManager.steplevelselection.CheckStageStatus(Stage_ID);   
        }
    }

    void Change_pic()
    {
        if(unlock)
        {
            Stage_image = LevelSelectionManager.steplevelselection.Unlock_Sprite;    
        }

        GetComponent<Image>().sprite = Stage_image;   
         
    }
}
