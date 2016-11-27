using UnityEngine;
using System.Collections;

public class QuestChecker : MonoBehaviour
{
    public int[] Quest_Ids;
    public QuestList._Quest_Status Quest_status;

    public bool Appear_object = false;
    public bool Hide_Object = false;

    public GameObject[] Objects;
    bool activated = false;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Quest_status.ToString()); 
        if (!activated)
        {
            CheckStatus();
        }
    }

    void CheckStatus()
    {
        bool res1 = false, res2 = false;  
        foreach(int i in Quest_Ids)
        {
            if(Quest_Manager.Steph_quest_manager.CheckQuest(i,Quest_status))
            {
                Debug.Log("weee"); 
                res1 = true;
            }
            else
            {
                res2 = true;
            }
        }
        
       if(res1 && !res2)
        {
            activated = true;
            if (Appear_object)
            {
                foreach(GameObject go in Objects)
                {

                    go.SetActive(true); 
                } 
            }

            if(Hide_Object)
            {
                foreach (GameObject go in Objects)
                {
                    go.SetActive(false);
                }
            }
        } 
    }
}
