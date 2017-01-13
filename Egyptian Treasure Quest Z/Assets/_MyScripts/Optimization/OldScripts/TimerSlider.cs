using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimerSlider : MonoBehaviour
{
    public int current_value;
    public int max_value;
    public GameObject timerUI;
    public GameObject timer_slider;
    
    void Start()
    {
        
        max_value = timerUI.GetComponent<DeathByTimer>().Timer_Threshold;

    }

    
    void Update()
    {
        current_value = timerUI.GetComponent<TimerObjective>().Seconds;
        timer_slider.GetComponent<Slider>().value = current_value;


        if (current_value >= max_value)
        {
            timerUI.SetActive(false);
        }
    }
}
