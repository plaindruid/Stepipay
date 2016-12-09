using UnityEngine;
using System.Collections;

public class PlayerAnimations : MonoBehaviour
{

    void OnEnable()
    {
        ButtonControllers._hide_player += Crouch_player;
        ButtonControllers._unhide_player += Stand_player;  
        //Debug.Log("Enabled ako"); 
    }

    void OnDisable()
    {
        ButtonControllers._hide_player -= Crouch_player;
        ButtonControllers._unhide_player -= Stand_player;
        //Debug.Log("Disabled Ako"); 
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void Crouch_player()
    {
        Debug.Log("nakatago ako"); 
    }

    void Stand_player()
    {
        Debug.Log("Nakatayo ako");  
    }
}
