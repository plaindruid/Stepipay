//ito yung ilalagay mo sa mag rerecieve ng Item mo

using UnityEngine;
using System.Collections;

public class ItemReciever : MonoBehaviour
{
    public int Quest_id_Required;
    public bool HasRequired = false;

    public bool TestRequired = false;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(TestRequired && !HasRequired)
        {
            CheckIhaveRequiredItems(); 
        }
        

    }

    //ito yung tatawagin mo sa raycast ng player mo
    public void CheckIhaveRequiredItems()
    {
        if (Quest_Manager.Steph_quest_manager.CheckQuest(Quest_id_Required, QuestList._Quest_Status.Obtained) && !HasRequired)
        {
            HasRequired = true;
            Quest_Manager.Steph_quest_manager.Quest_Completion(Quest_id_Required);
        }
        else
        {
            TestRequired = false;
        }
    }
    public void validate_Items()
    {
        if(Quest_Manager.Steph_quest_manager.CheckQuest(Quest_id_Required,QuestList._Quest_Status.Obtained))
        {
            CheckIhaveRequiredItems();
        }
    }


}
