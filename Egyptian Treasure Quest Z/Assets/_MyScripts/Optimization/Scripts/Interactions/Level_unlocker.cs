using UnityEngine;
using System.Collections;

public class Level_unlocker : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Player")
        {
            if(!SaveLoadManager .stageUnlocker .Stage_unlock_already )
            {
                SaveLoadManager .stageUnlocker.CheckStageQuest(SaveLoadManager.stageUnlocker.Stage_ID);  
            }
        }
    }
}
