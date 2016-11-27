using UnityEngine;
using System.Collections;

public class ItemScript : MonoBehaviour
{
    public int Quest_ID;
    public bool Obtained = false;
    public float FadeValue;
    float AlphaValue;
    bool FadeMat = false;
    Color MatColor;

    public ItemBehavior ib;

  

    void Start()
    {

        AlphaValue = 1;
      
    }
    
    void Update()
    {
        if (Obtained)
        {
            if (!FadeMat)
            {
                ChangeToFade();
            }
            
            if(AlphaValue >= 0)
            {
                StartFading();
            }
            else
            {
                Obtained = false;
                UpdateQuest(); 
            }
            
        }
    }

    void ChangeToFade()
    {
        #region Ito yung mag papa-change ng Opaque to Fade sa Material

        Material mat = GetComponent<Renderer>().material;
        mat.SetFloat("_Mode", 2);
        mat.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
        mat.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
        mat.SetInt("_ZWrite", 0);
        mat.DisableKeyword("_ALPHATEST_ON");
        mat.EnableKeyword("_ALPHABLEND_ON");
        mat.DisableKeyword("_ALPHAPREMULTIPLY_ON");
        mat.renderQueue = 3000;

        #endregion

        //Mag-aasign ng material color after mag change sa fade. need to para ma-change yung value ng alpha para sa fading
        MatColor = GetComponent<Renderer>().material.color;

        AlphaValue = 1;
        FadeMat = true;

    }

    void StartFading()
    {

       // Debug.Log("ImHere " + AlphaValue.ToString()); 
        AlphaValue -= Time.deltaTime * FadeValue;
        MatColor.a = AlphaValue;
        GetComponent<MeshRenderer>().material.SetColor("_Color", MatColor);
      
    }

    void UpdateQuest()
    {
       // Debug.Log("Update ko quest");
        Quest_Manager.Steph_quest_manager.Initialize_Quest(Quest_ID);
        if (ib != null)
        {
            ib.gotItem = true;
            ib.item_id = Quest_ID;
        }
        Destroy(gameObject); 
    }
    



}
