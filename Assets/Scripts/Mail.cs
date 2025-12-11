using UnityEngine;

public class Mail : ObstacleObject
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ObstacleSpeed = GameParameters.MailObjectSpeed; 
        isShooter = false;
        base.Start(); 
    }
    
}
