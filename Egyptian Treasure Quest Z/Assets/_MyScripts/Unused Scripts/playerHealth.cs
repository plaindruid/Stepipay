using UnityEngine;
using System.Collections;

public class playerHealth : MonoBehaviour {

	[SerializeField]
	public Stat health;
	private void Awake()
	{
		health.Initialize ();
        
        
    }
	void Update ()
    {
        if (health.CurrentVal <= 0)
        {
           // GameObject.Find("Text").SetActive(true);
        }
	}
}
