using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour {

    // Use this for initialization

    public GameObject tempGM;
    

    public void OnValueChanged(int value)
    {
        Debug.Log("New Value: " + value);
    }
}
