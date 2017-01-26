using UnityEngine;
using System.Collections;

public class Quest_Manager : MonoBehaviour
{
    public static Quest_Manager Steph_quest_manager = null;
    public QuestDatabase Quest_Database;

    public bool Reset_Quest = false;

	[Tooltip("Kung gusto mo totally reset including Index for Gallery")]
	public bool TotallyReset = false;



    #region For Events kung nag update yung quest - wag mo lang to pansinin kung hindi mo pa naiintindihan
    public int Quest_ID_Updated = 0;

    public delegate void Quest_Updated();
    public delegate void Quest_Completed();
    public static event Quest_Updated Quest_obtained;
    public static event Quest_Completed Quest_Finished;
    #endregion

     
    // Use this for initialization

    void Awake()
    {
        if (Steph_quest_manager == null)
        {
            Steph_quest_manager = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }

    void Start()
    {
        if(Reset_Quest)
        {
            Reset_All_Quest(); 
        }

		if (TotallyReset) 
		{
			ResetTotally_Quest ();
		}
    }

    #region Methods ng Quest manager


    //Method na tatawagin kung mag iinitialize ng quest or kukunin yung object para ma initialize yung quest. Need quest id para matuntun kung anong quest
    public void Initialize_Quest(int Quest_ID)
    {
        foreach(QuestList ql in Quest_Database.Quests)
        {
            if(ql.Quest_ID == Quest_ID)
            {
                Quest_ID_Updated = ql.Quest_ID; 
                ql.Quest_Status = QuestList._Quest_Status.Obtained;
                Update_quest(); 
            }
        } 
    }

    //Method na tatawagain para mag check ng quest status. Need quest id at quest status para mag-check, nag rereturn ito ng value na bool
    public bool CheckQuest(int Quest_Id, QuestList._Quest_Status Quest_Status)
    {
        bool res1 = false;
        //Debug.Log("dsfwefasfer");
        foreach (QuestList ql in Quest_Database.Quests)
        {
            if(ql.Quest_ID == Quest_Id && ql.Quest_Status == Quest_Status)
            {
                res1 = true;
            }
        }

        if(res1)
        {
            return true; //Return True kung sakto yung quest id and Quest status
        }
        else
        {
            return false;  //Return False kung hindi sakto yung quest id and Quest status
        }

    }

    //Method na tatawagin para mag-set ng completion status sa Quest Database. Need Quest id para matuntun yung quest na iccomplete;
    public void Quest_Completion(int Quest_ID)
    {
        foreach (QuestList ql in Quest_Database.Quests)
        {
            if (ql.Quest_ID == Quest_ID)
            {
                if (ql.Quest_Status != QuestList._Quest_Status.NotStarted || ql.Quest_Status != QuestList._Quest_Status.Fail)
                {
                    Quest_ID_Updated = ql.Quest_ID;
                    ql.Quest_Status = QuestList._Quest_Status.Completed;
					ql.Gallery_opened = true;
                    CompletedQuest(); 
                }
            }
        }
    }

    // Ito yung tatawagin mong method kung i-dedestroy mo yung gameManager object.
    public void DestroyQuestManager()
    {
        DestroyImmediate(gameObject); 
    }


    //Method kna mag rereset ng all quest
    void Reset_All_Quest()
    {
        foreach(QuestList ql in Quest_Database.Quests)
        {
            ql.Quest_Status = QuestList._Quest_Status.NotStarted; 
        } 
    }

	void ResetTotally_Quest()
	{
		foreach(QuestList ql in Quest_Database.Quests)
		{
			ql.Quest_Status = QuestList._Quest_Status.NotStarted; 
			ql.Gallery_opened = false;
		} 
	}
    public Sprite get_picture()
    {
        Sprite imageReturn = null;

        foreach (QuestList ql in Quest_Database.Quests)
        {
            if (ql.Quest_ID == Quest_ID_Updated)
            {
                ql.Quest_Status = QuestList._Quest_Status.Obtained;
                imageReturn = ql.Image; 
            }
        }
        return imageReturn; 

    }
    #region Wag mo muna intindihin to--- pwede mo din ito idelete yung nasa loob ng region na to

    void Update_quest()
    {
        if(Quest_obtained != null)
        {
            Quest_obtained(); 
        }
    }

    void CompletedQuest()
    {
        if(Quest_Finished != null)
        {
            Quest_Finished(); 
        }
    }

    #endregion
   
    #endregion


}
