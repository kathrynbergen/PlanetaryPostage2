using System;
using Unity.VisualScripting;
using UnityEngine;

public class Game : MonoBehaviour
{
    public UI UI;
    public LevelUI LevelUI;
    public AsteroidPlacer AsteroidPlacer;
    public AlienBasicPlacer AlienBasicPlacer;
    public  AlienShooterPlacer AlienShooterPlacer;
    public bool IsPlaying = false;
    
    public void Start()
    {
        // disable player movement
        //From cole: I think this is resolved? Lmk
        DisableObstacles();
    }
    public void OnStartLevelOneButtonClicked()
    {
        print("Level One Start");
        AdjustDifficultyToLevelOne();
        StartGame();
    }
    public void OnStartLevelTwoButtonClicked()
    {
        print("Level Two Start");
        AdjustDifficultyToLevelTwo();
        StartGame();
    }
    public void OnStartLevelThreeButtonClicked()
    {
        print("Level Three Start");
        AdjustDifficultyToLevelThree();
        StartGame();
    }

    private void DisableObstacles()
    {
        AsteroidPlacer.IsOkToCreate = false;
        AlienBasicPlacer.IsOkToCreate = false;
        AlienShooterPlacer.IsOkToCreate = false;
    }

    private void EnableObstacles()
    {
        AsteroidPlacer.IsOkToCreate = true;
        AlienBasicPlacer.IsOkToCreate = true;
        AlienShooterPlacer.IsOkToCreate = true;
    }
    private void StartGame()
    {
        ScoreKeeper.ResetScore();
        LevelUI.SetScoreText(ScoreKeeper.GetScore());
        UI.StartGame();
        UpdateSpawnRates();
        EnableObstacles();
        EnablePlayerMovement();
    }

    private void EnablePlayerMovement()
    {
        IsPlaying = true;
    }

    private void UpdateSpawnRates()
    {
        AsteroidPlacer.UpdateSpawnRates();
        AlienBasicPlacer.UpdateSpawnRates();
        AlienShooterPlacer.UpdateSpawnRates();
        
    }

    private void AdjustDifficultyToLevelOne()
    {
        UpdateGameParameters(2f, 4f, 2f, 6f, 3f, 6f);
    }
    private void AdjustDifficultyToLevelTwo()
    {
        UpdateGameParameters(1f,3f,2f,4f,2f,6f);
    }
    private void AdjustDifficultyToLevelThree()
    {
        UpdateGameParameters(0.5f,2.5f,1f,3f,1f,4f);
    }

    private void UpdateGameParameters(float asteroidMin, float asteroidMax, float alienBasicMin, float alienBasicMax, float alienShooterMin, float alienShooterMax)
    {
        GameParameters.AsteroidMinimumSecondsUntilSpawn = asteroidMin;
        GameParameters.AsteroidMaximumSecondsUntilSpawn = asteroidMax;
        
        GameParameters.AlienBasicMinimumSecondsUntilSpawn = alienBasicMin;
        GameParameters.AlienBasicMaximumSecondsUntilSpawn = alienBasicMax;

        GameParameters.AlienShooterMinimumSecondsUntilSpawn = alienShooterMin;
        GameParameters.AlienShooterMaximumSecondsUntilSpawn = alienShooterMax;
    }

    public void Update()
    {
        LevelUI.SetScoreText(ScoreKeeper.GetScore());
    }
}
