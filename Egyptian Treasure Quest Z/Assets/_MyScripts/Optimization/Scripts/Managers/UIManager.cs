using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour
{
    public static UIManager UI_manager;

    public GameObject GameUI;
    public GameObject PausedUI;
    public GameObject InvetoryUI;

    void Awake()
    {
        UI_manager = this;
    }



}
