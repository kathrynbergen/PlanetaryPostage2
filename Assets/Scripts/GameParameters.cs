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
    public static float ChuckParryCooldown = 5f;
    
    public static float ChuckBoostSpeed = 0.24f;
    public static float ChuckBoostDuration = 5f;
    
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
}
