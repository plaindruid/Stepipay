using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class ScoreManager : MonoBehaviour
{
    public Text player_score;

    public Text[] ScoresTxt;
    public HighScoreDB ScoreDB;
    int scoreIndex = 0;
    // Use this for initialization
    void OnEnable()
    {
        GameObject.Find("EventSystem").GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(GameObject.Find("btn_Hide_HiScore"));

        foreach(Scores sc in ScoreDB.score)
        {
            ScoresTxt[scoreIndex].text = sc.Score.ToString() ;
            scoreIndex++;
        }

        player_score.text = StephGameManager.instance.Score.ToString();
        GameObject.Find("EventSystem").GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(GameObject.Find("btn_Hide_HiScore"));
    }

    void OnDisable()
    {
        scoreIndex = 0;
    }
    
    public void Hide_Score()
    {
        gameObject.SetActive(false); 
    }
}
