using UnityEngine;
using System.Collections;

public class SceneDatabase : ScriptableObject
{
    public StageMaps[] Stage_Maps;
}



[System.Serializable]
public class StageMaps
{
    public int StageID;
    public bool Activated;
    public QuestList_Req[] Quest_Required; 
    public StageMaps()
    {

    }
}

[System.Serializable]
public class QuestList_Req
{
    public int Quest_Id;

    public QuestList_Req()
    {

    }
}