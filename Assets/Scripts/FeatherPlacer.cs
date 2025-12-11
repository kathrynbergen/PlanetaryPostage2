using UnityEngine;

public class FeatherPlacer : ObstacleObjectPlacer
{
    public void Start()
    {
        minimumSecondsUntilSpawn = GameParameters.FeatherObjectMinimumSecondsUntilSpawn; 
        maximumSecondsUntilSpawn = GameParameters.FeatherObjectMaximumSecondsUntilSpawn; 
    }

    public void UpdateSpawnRates()
    {
        minimumSecondsUntilSpawn = GameParameters.FeatherObjectMinimumSecondsUntilSpawn;
        maximumSecondsUntilSpawn = GameParameters.FeatherObjectMaximumSecondsUntilSpawn;
    }
}
