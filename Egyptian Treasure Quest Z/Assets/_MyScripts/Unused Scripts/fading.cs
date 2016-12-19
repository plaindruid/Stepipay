using UnityEngine;
using System.Collections;

public class fading : MonoBehaviour {

    public GameObject water;
    public GameObject camera;

    void Start()
    {
        this.gameObject.GetComponent<GUITexture>().pixelInset = new Rect(0f, 0f, Screen.width, Screen.height);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(camera.transform.localPosition.y + "-" + "-" + water.transform.localPosition.y);
        if (camera.transform.localPosition.y - 2 < water.transform.localPosition.y)
        {
            Debug.Log("nasa ilalim na si player");
            
        }
    }
}
