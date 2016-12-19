using UnityEngine;
using System.Collections;

public class BossEncounterAchievement : MonoBehaviour
{
    public enum _encounterType
    {
        Killed,
        Encounter,
        EncounterTrigger,
        None
    }

    public _encounterType EncounterType;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider col)
    {

    }

    void Activate_Achievement()
    {

    }
}
