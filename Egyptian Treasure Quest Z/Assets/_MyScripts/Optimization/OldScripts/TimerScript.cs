using UnityEngine;
using System.Collections;
using UnityEngine.UI;
//using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour
{
    public GameObject timerTxt;
    public float seconds;
    public int minutes = 0;
    bool isFlashing = false;
    float blinkingRate;
    public GameObject soundFx;
    public float timeStop = 0f;
    public GameObject tempGM;
    public bool stopTimer;



	// Use this for initialization
	void Start ()
    {
        tempGM = GameObject.FindGameObjectWithTag("GameManager");
        stopTimer = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        seconds -= Time.deltaTime;
        timerTxt.GetComponent<Text>().text = minutes.ToString("0:") + seconds.ToString("00");

        if (stopTimer)
        {
            gameObject.SetActive(false);
        }

        if (seconds <= 0)
        {
            seconds = 0;
        }

        if (seconds == timeStop)
        {
            tempGM.GetComponent<GameManager>().playerLife = 0;
        }

        if (seconds <= 5f)
        {
            Blinking();
            GameObject go = Instantiate(soundFx, transform.position, transform.rotation) as GameObject;
            Destroy(go, 1);
        }

      

        if (Input.GetKeyDown(KeyCode.P))
        {
            seconds = 0f;
            minutes = 0;
            timeStop = 5;
        }
       
        
      
	}

   

    void Blinking()
    {
        if (blinkingRate >= 0.5f)
        {
            blinkingRate = 0;

            if (isFlashing == false)
            {
                isFlashing = true;
                timerTxt.SetActive(true);
            }

            else
            {
                isFlashing = false;
                timerTxt.SetActive(false);

            }
        }

        blinkingRate += Time.deltaTime * 1f;
    }

}
