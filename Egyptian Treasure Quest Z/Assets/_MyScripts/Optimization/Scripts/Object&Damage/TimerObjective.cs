/// <summary>
/// Automatic umaandar ito pag na enabled ang script or na setActive yung Game Object na nilalagyan nito
/// </summary>

using UnityEngine;
using System.Collections;

public class TimerObjective : MonoBehaviour
{
    public enum TypeTimer
    {
        Increasing,
        Decreasing,
        No_Time
    }

    public TypeTimer Timer_Type;

    float Secs = 0;

    bool Timer_activated = false;

    [Tooltip("If you using Increasing Timer type")]
    public int Seconds;

    [Tooltip("If you using Increasing Timer type")]
    public int Minute;

    [Tooltip("If you using decreasing Timer type")]
    public int Decreasing_Minute;

    [Tooltip("If you using decreasing Timer type")]
    public int Decreasing_Secs;


    // Use this for initialization
    void Start()
    {
        Timer_Initialization();
    }

    private void Timer_Initialization()
    {
        switch (Timer_Type)
        {
            case TypeTimer.Increasing:
                Seconds = (int)Secs;
                Timer_activated = true;
                break;
            case TypeTimer.Decreasing:
                Decreasing_Secs = (int)Secs;
                Timer_activated = true;
                break;
            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
		
        switch(Timer_Type)
        {
            case TypeTimer.Increasing: IncreasingTime();
                break;
            case TypeTimer.Decreasing: DecreasingTime();
                break;
            default:
                break;

        }
      
    }

    private void IncreasingTime()
    {
        if (!Timer_activated)
        {
            Timer_Initialization();
        }

        Secs += Time.deltaTime;
        if (Seconds > 59)
        {
            Seconds = 0;
            Secs = 0;
            Minute++;
        }
        else
        {
            Seconds = (int)Secs;
        }
        //Debug.Log(Seconds.ToString());
    }

    private void DecreasingTime()
    {
        if(!Timer_activated)
        {
            Timer_Initialization();
        }

        if (Minute >=0)
        {
            if (Decreasing_Secs < 1)
            {
                Secs = 60;
                Decreasing_Minute--;
            }
            else
            {
                Secs -= Time.deltaTime;
            }

            Decreasing_Secs = (int)Secs;
        }
        else
        {
            Decreasing_Minute = 0;
            Decreasing_Secs = 0;
            Timer_Type = TypeTimer.No_Time;
        }
    }
}
