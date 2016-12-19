using UnityEngine;
using System.Collections;

public class LevelUnlockDB : ScriptableObject
{
       public Levels[] Levels_Locked;
}

[System.Serializable]
public class Levels
{
    public int level_index;
    public bool Unlocked = false;

    public Levels()
    {
        
    } 
}

