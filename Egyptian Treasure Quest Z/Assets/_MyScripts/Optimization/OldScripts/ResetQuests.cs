using UnityEngine;
using System.Collections;

public class ResetQuests : MonoBehaviour
{
    public bool ResetAll = false;

    public QuestDatabase myQuestDB;
    public SceneDatabase mySceneDB;

    public int[] quest_index;

    void OnEnable()
    {
        if (ResetAll)
        {
            Reset_All_Quest();
            ResetTotally_Quest();
            Reset_Scenes();
        }
        else
        {
            Reset_This_Quest();
        }

    }

   

    void Reset_All_Quest()
    {
        foreach (QuestList ql in myQuestDB.Quests)
        {
            ql.Quest_Status = QuestList._Quest_Status.NotStarted;
        }
    }

    void ResetTotally_Quest()
    {
        foreach (QuestList ql in myQuestDB.Quests)
        {
            ql.Quest_Status = QuestList._Quest_Status.NotStarted;
            ql.Gallery_opened = false;
        }
    }

    void Reset_Scenes()
    {
        mySceneDB.Stage_Maps[1].Activated = false;
        mySceneDB.Stage_Maps[2].Activated = false;
    }

    void Reset_This_Quest()
    {
        foreach (int q_index in quest_index)
        {
            myQuestDB.Quests[q_index].Quest_Status = QuestList._Quest_Status.NotStarted;
            myQuestDB.Quests[q_index].Gallery_opened = false;
        }
        
    }


}
