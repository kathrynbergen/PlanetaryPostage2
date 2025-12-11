using UnityEngine;

public static class GameParameters
{
    //CHUCK
    public static float ChuckMoveSpeed = 0.8f;
    public static float ChuckHealth = 3f;
    
    public static float ChuckPulseSpeed = 3.2f;
    public static float ChuckPulseDuration = 0.2f;
    
    public static float ChuckParrySpeed = 0.32f;
    public static float ChuckParryDuration = 0.5f;
    public static float ChuckParryCooldownIntervalBetweenSpriteChange = 1f;
    
    public static float TextFlashInterval = 0.1f;
    public static float TextFlashIntervalLong = 1f;
    
    public static float ChuckBoostSpeed = 0.24f;
    public static float ChuckBoostDuration = 5f;

    public static float ChuckShootingIconDuration = 3f;
    public static float ChuckDamageIconDuration = 1f;
    
    //OBSTACLES
    public static float AsteroidSpeed = -0.5f;
    public static float AsteroidMinimumSecondsUntilSpawn = 1f;
    public static float AsteroidMaximumSecondsUntilSpawn = 3f;
    
    public static float AlienBasicSpeed = -1f;
    public static float AlienBasicMinimumSecondsUntilSpawn = 2f;
    public static float AlienBasicMaximumSecondsUntilSpawn = 4f;
    
    public static float AlienShooterSpeed = -0.25f;
    public static float AlienShooterMinimumSecondsUntilSpawn = 2f;
    public static float AlienShooterMaximumSecondsUntilSpawn = 6f;

    public static float BulletSpeed = -1f;
    public static float ObstacleXSpawnCoordinate = 2f;
    
    // COLLECTABLES
    public static float ChuckScore = 0f;
    
    public static float MailObjectSpeed = -0.5f;
    public static float MailObjectMinimumSecondsUntilSpawn = 1f;
    public static float MailObjectMaximumSecondsUntilSpawn = 3f;
    
    public static float FeatherObjectSpeed = -0.5f;
    public static float FeatherObjectMinimumSecondsUntilSpawn = 2f;
    public static float FeatherObjectMaximumSecondsUntilSpawn = 4f;
}
