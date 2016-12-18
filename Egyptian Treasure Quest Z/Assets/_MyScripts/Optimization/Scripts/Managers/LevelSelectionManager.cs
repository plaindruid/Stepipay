using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelSelectionManager : MonoBehaviour
{
    public static LevelSelectionManager steplevelselection;
    public SceneDatabase Stage_Database;
    public Sprite Lock_Sprite;
    public Sprite Unlock_Sprite;

    void Awake()
    {
        steplevelselection = this;
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool CheckStageStatus(int Stage_ID)
    {
        bool unlocked = false;
        foreach (StageMaps s_maps in Stage_Database.Stage_Maps)
        {
            if (s_maps.StageID == Stage_ID)
            {
                if (s_maps.Activated)
                {
                    unlocked = true;
                }
            }
        }
        return unlocked; 
    }
}
