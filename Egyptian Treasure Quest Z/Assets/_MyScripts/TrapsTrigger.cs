using UnityEngine;
using System.Collections;

public class TrapsTrigger : MonoBehaviour
{ 
    public Animator[] animators;
    

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            foreach (Animator anim in animators)
            {
                anim.SetBool("isTriggered", true);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            foreach (Animator anim in animators)
            {
                anim.SetBool("isTriggered", false);
            }
        }
    }
}
