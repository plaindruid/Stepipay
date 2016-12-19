using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    static GameManager gmInstance;

    GameObject player;
    public bool playerIsDamaged = false;
    public float playerLife;
    public float maxLife = 100;
    public float score;
    public GameObject lifetxt;
    public GameObject scoretxt;
    public GameObject bloodUI;
    public GameObject gameOver;

    public int level = 1;
    //public float timer = 0f;

    

    void Start()
    {
        playerLife = maxLife;
    }


    void Awake ()
    {
        if (gmInstance != null)
        {
            GameObject.Destroy(gameObject);
        }
        else
        {
            GameObject.DontDestroyOnLoad(gameObject);
            gmInstance = this;
        }

        player = GameObject.FindGameObjectWithTag("Player");
        
    }

    void Update()
    {
        
        if (playerLife < 0)
        {
            playerLife = 0;

        }
        if (playerLife >= maxLife)
        {
            playerLife = maxLife;
        }

        lifetxt.GetComponent<Text>().text = playerLife.ToString() + " / 100";
        scoretxt.GetComponent<Text>().text = score.ToString();

        //for Dugo effect in UI Canvas
        //pag life ay 76-100
        //if (playerLife >= 76 && playerLife <= 100)
        //{
        //    life2.SetActive(false);
        //    life1.SetActive(false);
        //    life0.SetActive(false);
        //}
        ////pag life ay 50-75
        //if (playerLife >= 50 && playerLife <= 75)
        //{
        //    life2.SetActive(true);
        //}
        ////pag life ay 1-49
        //if (playerLife >= 1 && playerLife <= 49)
        //{
        //    life2.SetActive(false);
        //    life1.SetActive(true);
        //}
        //if player is dead
        if (playerLife <= 0)
        {
            gameOver.SetActive(true);
            StartCoroutine(backToMainMenu());
        }

        
    }

    void FixedUpdate()
    {
        //timer += Time.deltaTime;

        //if (timer >= 0 && timer <= 300)
        //{
        //    //level1
        //    level = 1;
        //}
        //else if (timer > 300 && timer <= 570)
        //{
        //    //level2
        //    level = 2;
        //}
        //else if (timer > 570 && timer <= 810)
        //{
        //    //level3
        //    level = 3;
        //}
        //else if (timer > 810 && timer <= 1020)
        //{
        //    //level4
        //    level = 4;
        //}
        //else if (timer > 1020 && timer <= 1200)
        //{
        //    level = 5;
        //}
        //else
        //{
        //    Debug.Log("YOU WIN");
        //}
        //Debug.Log("Level " + level.ToString());



    }

    IEnumerator backToMainMenu()
    {
        yield return new WaitForSeconds(5);
        Destroy(player);
        SceneManager.LoadScene("Menu");
    }
}
