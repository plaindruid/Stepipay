using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class ShowInfoScript : MonoBehaviour
{
    public QuestDatabase Quest_Database;
    GameObject player;
    public GameObject trivia;
    public GameObject btn_Close;
    public int q_id;
    public GameObject _item1;
    public GameObject _item2;
    public GameObject _item3;
    public GameObject _item4;
    public GameObject _item5;
    public GameObject _item6;
    public GameObject _item7;
    public GameObject _item8;
    public GameObject _item9;
    public GameObject _item10;
    public GameObject _item11;
    public GameObject _item12;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    
    void Update()
    {
        
        switch (q_id)
        {
            case 4:
                trivia = _item1;
                break;

            case 5:
                trivia = _item2;
                break;

            case 6: 
                trivia = _item3;
                break;

            case 7:
                trivia = _item4;
                break;

            case 8:
                trivia = _item5;
                break;

            case 9:
                trivia = _item6;
                break;

            case 10:
                trivia = _item7;
                break;

            case 11:
                trivia = _item8;
                break;

            case 12:
                trivia = _item9;
                break;

            case 13:
                trivia = _item10;
                break;

            case 14:
                trivia = _item11;
                break;

            case 15:
                trivia = _item12;
                break;

        }

        CheckIfItemObtained(q_id);

    }

    public void CheckIfItemObtained(int item_id)
    {
        foreach (QuestList ql in Quest_Database.Quests)
        {
            if (ql.Quest_ID == item_id)
            {
                if (ql.Quest_Status == QuestList._Quest_Status.Obtained)
                {
                    showTrivia();
                }
                else
                {
                    trivia = null;
                }
                
            }
        }
    }

    public void showTrivia()
    {
        trivia.SetActive(true);
        btn_Close.SetActive(true);
        GameObject myEventSystem = GameObject.Find("EventSystem");
        myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(btn_Close);
        Time.timeScale = 0;
        player.GetComponent<FirstPersonController>().enabled = false;
    }



    public void pressClose()
    {
        trivia.SetActive(false);
        Time.timeScale = 1;
        player.GetComponent<FirstPersonController>().enabled = true;
        btn_Close.SetActive(false);
        Quest_Database.Quests[q_id - 1].Quest_Status = QuestList._Quest_Status.Displayed;
    }
}
