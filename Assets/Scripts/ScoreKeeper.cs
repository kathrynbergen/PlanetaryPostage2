using System;
using UnityEngine;


public static class ScoreKeeper
{
    public static void AddPoint()
    {
        GameParameters.ChuckScore += 100f;
    }
    
    public static void AddBigPoint()
    {
        GameParameters.ChuckScore += 1000f;
    }
  
    public static void ResetScore()
    {
        GameParameters.ChuckScore = 0f;
    }
  
}