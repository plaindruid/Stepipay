using UnityEngine;
using System.Collections;

public class ResumeScript : MonoBehaviour
{
    public void Resume()
    {
        StephGameManager.instance.PausedGame(); 
    }

    public void QuitGame()
    {
        StephGameManager.instance.QuitGame(); 
    }

    public void Inventory()
    {
        StephGameManager.instance.Inventory();
    }
    
}
