using UnityEngine;
using System.Collections;

public class ResetQuests : MonoBehaviour
{
    public QuestDatabase myQuestDB;
    public SceneDatabase mySceneDB;

    void OnEnable()
    {
        Reset_All_Quest();
        ResetTotally_Quest();
        Reset_Scenes();
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


}
