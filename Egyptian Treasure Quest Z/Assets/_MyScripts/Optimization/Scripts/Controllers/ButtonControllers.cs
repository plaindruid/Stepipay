using UnityEngine;
using System.Collections;

public class ButtonControllers : MonoBehaviour
{
    
    public delegate void HidePlayer();
    public delegate void PausedGame();
    public delegate void UnHidePlayer();

    public static event PausedGame _pause_game;
    public static event HidePlayer _hide_player;
    public static event UnHidePlayer _unhide_player;

    public KeyCode PauseKey;
    
    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(Input.GetKey(KeyCode.LeftControl))
        {
            Hide_Player(); 
        }

        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            UnHide_Player();
        }
        if((Input.GetKeyDown(PauseKey)) || (Input.GetButtonDown("Fire2")))
        {
            Paused_Game();
        }
    }

    void Hide_Player()
    {
        if (_hide_player != null)
            _hide_player();
    }

    void UnHide_Player()
    {
        if (_unhide_player != null)
            _unhide_player();
    }

    void Paused_Game()
    {
        if (_pause_game != null)
            _pause_game();
    }
        
}
