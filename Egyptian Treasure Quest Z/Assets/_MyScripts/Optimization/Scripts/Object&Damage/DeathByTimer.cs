using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

[RequireComponent(typeof(TimerObjective))]
public class DeathByTimer : MonoBehaviour
{
	public GameObject Timer_ui; 
	public int Timer_Threshold;
	public enum _Threshold_Type
	{
		Seconds,
		Minutes
	}

	public _Threshold_Type  Threshold_Type;

	bool Activated = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Timer_ui != null) {
			if (!Timer_ui.activeSelf) {
				Timer_ui.SetActive (true);  
			}

			if (GetComponent<TimerObjective> ().Timer_Type == TimerObjective.TypeTimer.Increasing) {
				if (Threshold_Type == _Threshold_Type.Seconds) {
					if (Timer_Threshold <= GetComponent<TimerObjective> ().Seconds) {
						StephGameManager.instance.Lose = true;   
					}
				}

				if (Threshold_Type == _Threshold_Type.Minutes) {
					if (Timer_Threshold <= GetComponent<TimerObjective> ().Minute) {
						StephGameManager.instance.Lose = true;   
					}
				}
				Timer_ui.GetComponent<Text> ().text = GetComponent<TimerObjective> ().Minute.ToString () + " : " + GetComponent<TimerObjective> ().Seconds.ToString (); 
			}

			if (GetComponent<TimerObjective> ().Timer_Type == TimerObjective.TypeTimer.Decreasing) {
				if (Threshold_Type == _Threshold_Type.Seconds) {
					if (Timer_Threshold >= GetComponent<TimerObjective> ().Decreasing_Secs) {
						StephGameManager.instance.Lose = true;   
					}
				}

				if (Threshold_Type == _Threshold_Type.Minutes) {
					if (Timer_Threshold >= GetComponent<TimerObjective> ().Decreasing_Minute) {
						StephGameManager.instance.Lose = true;   
					}
				}
				Timer_ui.GetComponent<Text> ().text = GetComponent<TimerObjective> ().Decreasing_Minute.ToString () + " : " + GetComponent<TimerObjective> ().Decreasing_Secs.ToString ();
			}

		} else {
			Debug.LogWarning ("Wala naka Set Timer UI mo"); 
		}
	}
}
