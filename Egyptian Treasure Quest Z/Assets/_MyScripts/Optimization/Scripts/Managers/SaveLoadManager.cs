using UnityEngine;
using System.Collections;

public class SaveLoadManager : MonoBehaviour
{
    public int Stage_ID;
    public SceneDatabase Scene_DB;
    public QuestDatabase Quest_Database;
    // Use this for initialization


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CheckStageQuest(Stage_ID);
    }

    public void CheckStageQuest(int StageID)
    {
        foreach (StageMaps s_maps in Scene_DB.Stage_Maps)
        {
            if (s_maps.StageID == StageID)
            {
                if (s_maps.Quest_Required.Length > 0)
                {
                    bool res1 = false, res2 = false;
                    foreach (QuestList_Req q_req in s_maps.Quest_Required)
                    {
                        if (CheckQuest(q_req.Quest_Id, QuestList._Quest_Status.Completed))
                        {
                            res1 = true;
                        }
                        else
                        {
                            res2 = true;
                        }
                    }
                    if (res1 && !res2)
                    {
                        s_maps.Activated = true;
                    }
                }
                else
                {
                    Debug.Log("No Quest list Required");
                }
            }
        }
    }

    public bool CheckQuest(int Quest_Id, QuestList._Quest_Status Quest_Status)
    {
        bool res1 = false;
        //Debug.Log("dsfwefasfer");
        foreach (QuestList ql in Quest_Database.Quests)
        {
            if (ql.Quest_ID == Quest_Id && ql.Quest_Status == Quest_Status)
            {
                res1 = true;
            }
        }

        if (res1)
        {
            return true; //Return True kung sakto yung quest id and Quest status
        }
        else
        {
            return false;  //Return False kung hindi sakto yung quest id and Quest status
        }

    }
}
