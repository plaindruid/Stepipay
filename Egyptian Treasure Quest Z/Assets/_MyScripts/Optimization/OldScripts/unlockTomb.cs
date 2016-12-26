using UnityEngine;
using System.Collections;

public class unlockTomb : MonoBehaviour
{

    public Animator anim;
    //public GameObject timer;
    //public int seconds_;

    void Update()
    {
        //timer = GameObject.FindGameObjectWithTag("timer");
    }

    void OnEnable()
    {
        anim.SetBool("isLocked", false);
        //timer.GetComponent<TimerScript>().seconds = seconds_;
    }
}
