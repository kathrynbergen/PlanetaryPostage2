using UnityEngine;

public class MailPlacer : ObstacleObjectPlacer
{
    public void Start()
    {
        minimumSecondsUntilSpawn = GameParameters.MailObjectMinimumSecondsUntilSpawn; 
        maximumSecondsUntilSpawn = GameParameters.MailObjectMaximumSecondsUntilSpawn; 
    }

    public void UpdateSpawnRates()
    {
        minimumSecondsUntilSpawn = GameParameters.MailObjectMinimumSecondsUntilSpawn;
        maximumSecondsUntilSpawn = GameParameters.MailObjectMaximumSecondsUntilSpawn;
    }
}
