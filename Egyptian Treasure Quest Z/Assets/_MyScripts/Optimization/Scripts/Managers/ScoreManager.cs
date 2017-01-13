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
        foreach(Scores sc in ScoreDB.score)
        {
            ScoresTxt[scoreIndex].text = sc.Score.ToString() ;
            scoreIndex++;
        }

        player_score.text = StephGameManager.instance.Score.ToString();
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
