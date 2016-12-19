using UnityEngine;
using System.Collections;

public class underWaterEffect : MonoBehaviour {

    public GameObject water;
    public GameObject camera;
    
	void Start ()
    {
        camera = this.gameObject;
    }
	
	void Update ()
    {
        //Debug.Log(camera.transform.localPosition.y + "-" + "-" + water.transform.localPosition.y);
        if (camera.transform.localPosition.y -2 < water.transform.localPosition.y)
        {
            Debug.Log("nasa ilalim na si player");
            RenderSettings.ambientEquatorColor = Color.black;
            RenderSettings.ambientGroundColor = Color.black;
            RenderSettings.ambientSkyColor = Color.black;
            RenderSettings.ambientIntensity = 8;

            RenderSettings.fogColor = Color.black;
            
            
        }
	}
}
