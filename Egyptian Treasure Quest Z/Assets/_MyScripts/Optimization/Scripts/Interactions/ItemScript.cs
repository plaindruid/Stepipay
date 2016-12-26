using UnityEngine;
using System.Collections;

public class ItemScript : MonoBehaviour
{
    public enum itemtype
    {
        Quest_Item,
        Pickup_Items
    }
    public enum _collidertypes
    {
        Box,
        Sphere,
        Capsule,
        Mesh
    }

    public itemtype ItemType;
    public _collidertypes Collider_Type;


    public int Quest_ID;
    public int Item_ID;
    public bool Obtained = false;
    public float FadeValue;
    public bool Heal_player = false;
    public float Heal_Ammount;
    public bool Antidote = false;
    public bool Activated = false;
    public double Score;
    public AudioSource itemSound;
    float AlphaValue;
    bool FadeMat = false;
    Color MatColor;



    void Start()
    {

        AlphaValue = 1;

    }

    void Update()
    {
        if (Obtained)
        {
            if (GetComponent<MeshRenderer>() != null)
            {
                if (!FadeMat)
                {
                    ChangeToFade();
                }

                if (AlphaValue >= 0)
                {
                    StartFading();
                }
                else
                {
                    Obtained = false;
                    UpdateQuest();
                }
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

    //Start Fading
    void StartFading()
    {


        AlphaValue -= Time.deltaTime * FadeValue;
        MatColor.a = AlphaValue;
        GetComponent<MeshRenderer>().material.SetColor("_Color", MatColor);

    }


    //Check nya kung quest item sya or Pickable Items
    void UpdateQuest()
    {
        switch (ItemType)
        {
            case itemtype.Quest_Item:
                QuestItem();
                break;
            case itemtype.Pickup_Items:
                PickUpItems();
                break;
            default:
                break;
        }
    }

    //Ito kung quest Items sya
    void QuestItem()
    {

        Quest_Manager.Steph_quest_manager.Initialize_Quest(Quest_ID);
        //Destroy(gameObject);
        HideItems();
    }


    //Ito kung pickup items example potion and Antidotes
    void PickUpItems()
    {
        if (Heal_player) //Mag hiheal yung player if na ka true yung Heal_player na flag. Heal nya dipende sa ammount na nilagay mo sa Heal ammount
        {
            StephGameManager.instance.Player_Stat.Heal_player(Heal_Ammount);
        }
        if (Antidote) //Cure ng status effect like poison 
        {
            StephGameManager.instance.Player_Stat.Cure_Status();
        }

        if(Score > 0)
        {
            StephGameManager.instance.Score += Score;
            if (itemSound != null)
            {
                itemSound.Play();
            }
        }
        HideItems(); 
    }

    //Hindi ko na sya dinestroy dahil need tin sila kung mag sesave ka ng game
    public void HideItems()
    {
        Activated = true;

        if (GetComponent<MeshRenderer>() != null)
        {
            GetComponent<MeshRenderer>().enabled = false;
        }
        else
        {
            transform.gameObject.SetActive(false);  
        }

        switch (Collider_Type)
        {
            case _collidertypes.Box:
                GetComponent<BoxCollider>().enabled = false;
                break;
            case _collidertypes.Sphere:
                GetComponent<SphereCollider>().enabled = false;
                break;
            case _collidertypes.Capsule:
                GetComponent<CapsuleCollider>().enabled = false;
                break;
            case _collidertypes.Mesh:
                GetComponent<MeshCollider>().enabled = false;
                break;
            default:
                break;

        }
       
    }


}
