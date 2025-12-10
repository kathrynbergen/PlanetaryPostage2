using Unity.VisualScripting;
using UnityEngine;


public class Game : MonoBehaviour
{
   public UI UI;
   public UI_ProgressBar ProgressBar;
   public HealthDisplay HealthDisplay;
   public AsteroidPlacer AsteroidPlacer;
   public AlienBasicPlacer AlienBasicPlacer;
   public AlienShooterPlacer AlienShooterPlacer;
   public bool IsPlaying = false;
  
   public void Start()
   {
       DisableObstacles();
       UI.ReturnToMenu();
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


   public void OnRestartButtonClicked()
   {
       StartGame();
   }


   public void OnReturnToMenuButtonClicked()
   {
       UI.ReturnToMenu();
   }


   public void GameOver()
   {
       ProgressBar.StopMovement();
       DisablePlayerMovement();
       DisableObstacles();
       UI.GameOver();
   }


   private void DisableObstacles()
   {
       AsteroidPlacer.IsOkToCreate = false;
       AsteroidPlacer.IsGameOver = true;
       AlienBasicPlacer.IsOkToCreate = false;
       AlienBasicPlacer.IsGameOver = true;
       AlienShooterPlacer.IsOkToCreate = false;
       AlienShooterPlacer.IsGameOver = true;
   }


   private void EnableObstacles()
   {
       AsteroidPlacer.IsOkToCreate = true;
       AsteroidPlacer.IsGameOver = false;
       AlienBasicPlacer.IsOkToCreate = true;
       AlienBasicPlacer.IsGameOver = false;
       AlienShooterPlacer.IsOkToCreate = true;
       AlienShooterPlacer.IsGameOver = false;
   }
   private void StartGame()
   {
       UI.StartGame();
       UpdateSpawnRates();
       EnableObstacles();
       EnablePlayerMovement();
       ProgressBar.StartMovement();
       
       // reset all values to initial
       ResetHealth();
       // reset score to 0
   }


   private void ResetHealth()
   {
       HealthDisplay.Health = 3f;
       UI.ShowHealth();
   }
   private void EnablePlayerMovement()
   {
       IsPlaying = true;
   }

   private void DisablePlayerMovement()
   {
       IsPlaying = false;
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
}
