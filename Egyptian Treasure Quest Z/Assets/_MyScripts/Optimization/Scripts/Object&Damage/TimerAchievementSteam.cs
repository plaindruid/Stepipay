using UnityEngine;
using System.Collections;


[RequireComponent(typeof(TimerObjective))]
public class TimerAchievementSteam : MonoBehaviour
{
    public int Minute_Required = 0;
    public int Seconds_Required = 0;

    public bool no_time = false;
    // Use this for initialization
    void Start()
    {
        no_time = (Minute_Required == 0 && Seconds_Required == 0) ? true : false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!no_time)
        {
            if(GetComponent<TimerObjective>().Timer_Type == TimerObjective.TypeTimer.No_Time)
            {
                Debug.Log("Hello");
                if(Minute_Required <= GetComponent<TimerObjective>().Minute && Seconds_Required > GetComponent<TimerObjective>().Seconds)
                {
                    Activate_Achievements();
                }
            }
        }
    }

    void Activate_Achievements()
    {
        Debug.Log("Test ko");
    }
}
