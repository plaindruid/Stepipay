using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;  


public class StephGameManager : MonoBehaviour
{
    #region public Variables
	public bool Debug_mode = false;
    public static StephGameManager instance;
    public HighScoreDB ScoreDatabase;
    public GameObject Player;
    public PlayerStats Player_Stat;
    public GameObject Healthbar_UI;
	public Text ScoreUI;
    public float Health;
    public double Score;
    public bool IsPaused = false;
    
    public GameObject GameUI;
    public GameObject PausedUI;
    public GameObject InventoryUI;

    public GameObject UICanvas;

	public GameObject GameoverUI;
	public GameObject ScoreUIGO;
	public bool PlayerDead = false;
    
    GameObject LifegauageIndicator;
    public bool Win = false,Lose = false;
    bool ShowInv = false;
	Scene Scene_name;
    #endregion

    void OnEnable()
    {
        ButtonControllers._pause_game += PausedGame;
    }

    void OnDisable()
    {
        ButtonControllers._pause_game -= PausedGame;
    }

    void Awake()
    {
		if (instance == null) 
		{
			instance = this;
			DontDestroyOnLoad (gameObject);
		} 
		else 
		{
			DestroyImmediate (gameObject); 
		}
	}
    // Use this for initialization
    void Start()
    {
        if(Player == null)
        {
            Player = GameObject.FindGameObjectWithTag("Player");
            Player_Stat = Player.GetComponent<PlayerStats>();
            LifegauageIndicator = Healthbar_UI.transform.GetChild(0).gameObject;   
        }
    }

    // Update is called once per frame
    void Update()
	{
		if (!PlayerDead)
		{
		Get_PlayerStat ();
		GameStatus ();
		Display_Score ();
		}

	
    }

    private void GameStatus()
    {
        if (Win)
        {
			Set_Score();
			Display_ScoreUI(); 
        }

        if (Lose)
        {
			PlayerDead = true;
			Lose = false;
			GameoverUI.SetActive (true);
			GameUI.SetActive (false); 
			Invoke ("Display_ScoreUI", 2);
            Set_Score();
        }
    }

    void Get_PlayerStat()
    {
        Healthbar_UI.GetComponent<Scrollbar>().size = ((Player_Stat.Get_life()) * 0.01f);
        Health = ((Player_Stat.Get_life()) * 0.01f);
        if (Player_Stat.Get_life() == 0)
        {
            LifegauageIndicator.SetActive(false);
            Lose = true;
        }
    }

    public void PausedGame()
    {
        UIInitialization();

        if (!IsPaused)
        {
            IsPaused = true;

            if (GameUI != null && PausedUI != null)
            {
                GameUI.SetActive(false);
                PausedUI.SetActive(true);
                GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(GameObject.Find("ResumeBtn").gameObject);
            }



            Time.timeScale = 0;

        }
        else
        {
            IsPaused = false;

            if (GameUI != null)
            {
                GameUI.SetActive(true);
                PausedUI.SetActive(false);
            }

            Time.timeScale = 1;
        }
    }

    private void UIInitialization()
    {
        if (GameUI == null)
        {
            GameUI = UIManager.UI_manager.GameUI;
        }
        if (PausedUI == null)
        {
            PausedUI = UIManager.UI_manager.PausedUI;
        }
    }


    public void QuitGame()
    {
        Time.timeScale = 1;

        //Ikaw na dito mag lagay ng pang quit mo dahil luma pa ito
        Application.Quit();
    }

    public void Inventory()
    {
        if(IsPaused && !ShowInv)
        {
            GameUI.SetActive(false);
            PausedUI.SetActive(false);
        }
    }

	public void Display_Score()
	{
		ScoreUI.text = Score.ToString ();   
	}

    public void Set_Score()
    {
        double tempScore1 = Score, tempScore2 = 0;     
        foreach (Scores sc in ScoreDatabase.score)
        {
            if (tempScore1 >= sc.Score)
            {
                tempScore2 = sc.Score;
                sc.Score = tempScore1;
                tempScore1 = tempScore2;
            } 
        }
    }

	void Display_ScoreUI()
	{
		Player.GetComponent<FirstPersonController> ().enabled = false;    
		if (Win) 
		{
			Win = false;
			ScoreUIGO.SetActive (true); 
			GameUI.SetActive (false); 
		}
		else 
		{
		
			GameoverUI.SetActive (false);
			ScoreUIGO.SetActive (true); 
			Invoke ("Reset_game", 5);
		}

	}

	void Reset_game()
	{
		// lagay ng pa change scene
		SceneManager.LoadScene("Menu");
		Quest_Manager.Steph_quest_manager.DestroyQuestManager (); 
		Destroy (gameObject);
	}
}
