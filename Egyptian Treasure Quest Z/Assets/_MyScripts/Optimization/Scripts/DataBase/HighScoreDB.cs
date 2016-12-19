using UnityEngine;
using System.Collections;

public class HighScoreDB : ScriptableObject
{
    public Scores[] score; 
}


[System.Serializable]
public class Scores
{
    public double Score;

    public Scores()
    {

    }
}
