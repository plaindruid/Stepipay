using UnityEngine;
using System.Collections;
using UnityEngine.UI;

 
public class QuestDatabase : ScriptableObject
{
    public QuestList[] Quests; 
    
}


[System.Serializable]
public class QuestList
{
    [Tooltip("Quest ID")]
    public int Quest_ID;

    [Tooltip("Quest_name")]
    public string Quest_name;

    [Tooltip("Quest Description or Relic Description") ]
    public Sprite QuestDescription;
       
    public enum _Quest_Status
    {
        NotStarted,
        Obtained,
        Completed,
        Displayed,
        Fail
    }

    [Tooltip("Quest Status")]
    public _Quest_Status Quest_Status;

   
    public enum _Quest_Property
    {
        Local,
        Global
    }
    [Tooltip("Quest Property--Kung Global or local")]
    public _Quest_Property Quest_Property;

    [Tooltip("Image ng Item")]
    public Sprite Image;

    [Tooltip("Prefab ng Item")]
    public GameObject Prefab_Object;     
    
    
    public QuestList()
    {

    }

}