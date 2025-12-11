using UnityEngine;

public class BoostFeather : ObstacleObject
{
    void Start()
    {
        ObstacleSpeed = GameParameters.FeatherObjectSpeed; 
        isShooter = false;
        base.Start(); 
    }
    
}
