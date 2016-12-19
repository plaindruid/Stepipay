using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class barScript : MonoBehaviour {

	[SerializeField]
	private float fillAmount;

	[SerializeField]
	private Image content;

	[SerializeField]
	private Text valueText;

	[SerializeField]
	private float lerpSpeed;
	public float maxValue
    {
		get;
		set;
	}

	public float Value
	{
		set 
		{
			string[] tmp = valueText.text.Split (':');
			valueText.text = tmp[0] + ": "+ value;
			fillAmount = Map (value,0,maxValue,0,1);
		}
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		HandleBar ();
	}

	private void HandleBar()
	{
		if(fillAmount != content.fillAmount)
		{
			content.fillAmount = Mathf.Lerp(content.fillAmount, fillAmount, Time.deltaTime * lerpSpeed);
		}
	}
	private float Map(float value, float inMin, float inMax, float outMin, float outMax)
	{
		return (value - inMin) * (outMax - inMin) / (inMax - inMin) + outMin;
	}

}
