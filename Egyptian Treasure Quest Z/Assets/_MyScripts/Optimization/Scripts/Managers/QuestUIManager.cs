//Quest UI ok lang kung gagamitin or hindi Gagamitin


using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class QuestUIManager : MonoBehaviour
{
    public GameObject[] imageContainer;
    public int[] QuestId;

    #region eto yung maglalagay sa event at mag reremove ng event sa script na to---- wag mo syadong galawin ito para hindi ka mag memory leak
    void OnEnable()
    {
        Quest_Manager.Quest_obtained += AddPicture;
        Quest_Manager.Quest_Finished += RemovePicture;  
    }

    void OnDisable()
    {
        Quest_Manager.Quest_obtained -= AddPicture;
        Quest_Manager.Quest_Finished -= RemovePicture;
    }

    #endregion
    // Use this for initialization
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void AddPicture()
    {
        if (imageContainer.Length > 0)
        {
            Color mat;
            int index = 0;
            foreach (GameObject go in imageContainer)
            {
                if (go.GetComponent<Image>().sprite == null)
                {
					 
                    go.GetComponent<Image>().sprite = Quest_Manager.Steph_quest_manager.get_picture();
                    mat = go.GetComponent<Image>().color;
                    mat.a = 1;
                    go.GetComponent<Image>().color = mat;
                    QuestId[index] = Quest_Manager.Steph_quest_manager.Quest_ID_Updated;
                    break;
                }
                else
                {
                    index++;
                }
            }
        }
    }

    void RemovePicture()
    {
        if (imageContainer.Length > 0)
        {
            Color mat = Color.white ;
            mat.a = 0;
            int index = 0;
            foreach (int i in QuestId)
            {
                if (i == Quest_Manager.Steph_quest_manager.Quest_ID_Updated)
                {
                    imageContainer[index].GetComponent<Image>().sprite = null;
                    imageContainer[index].GetComponent<Image>().color = mat;
                    QuestId[index] = 0;
                    break;
                }
                else
                {
                    index++;
                }
            }
        }
    }
}
