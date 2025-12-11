using Unity.VisualScripting;
using UnityEngine;


public class Game : MonoBehaviour
{
   public UI UI;
   public QuickTimeEvent QTE;
   public ProgressBarIcon ProgressBar;
   public HealthDisplay HealthDisplay;
   public AsteroidPlacer AsteroidPlacer;
   public AlienBasicPlacer AlienBasicPlacer;
   public AlienShooterPlacer AlienShooterPlacer;
   public FeatherPlacer FeatherPlacer;
   public MailPlacer MailPlacer;
   public bool IsPlaying = false;
  
   public void Start()
   {
       DisableObstacles();
       UI.ReturnToMenu();
   }
   public void OnStartLevelOneButtonClicked()
   {
       AdjustDifficultyToLevelOne();
       StartGame();
   }
   public void OnStartLevelTwoButtonClicked()
   {
       AdjustDifficultyToLevelTwo();
       StartGame();
   }
   public void OnStartLevelThreeButtonClicked()
   {
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
       QTE.ForceStop();
       DisablePlayerMovement();
       DisableObstacles();
       DestroyObstacles();
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
       FeatherPlacer.IsOkToCreate = false;
       FeatherPlacer.IsGameOver = true;
       MailPlacer.IsOkToCreate = false;
       MailPlacer.IsGameOver = true;
   }

   private void DestroyObstacles()
   {
       AsteroidPlacer.DestroyObstacle();
       AlienBasicPlacer.DestroyObstacle();
       AlienShooterPlacer.DestroyObstacle();
       FeatherPlacer.DestroyObstacle();
       MailPlacer.DestroyObstacle();
   }


   private void EnableObstacles()
   {
       AsteroidPlacer.IsOkToCreate = true;
       AsteroidPlacer.IsGameOver = false;
       AsteroidPlacer.SpawnCoroutine = null;
       AlienBasicPlacer.IsOkToCreate = true;
       AlienBasicPlacer.IsGameOver = false;
       AlienBasicPlacer.SpawnCoroutine = null;
       AlienShooterPlacer.IsOkToCreate = true;
       AlienShooterPlacer.IsGameOver = false;
       AlienShooterPlacer.SpawnCoroutine = null;
       FeatherPlacer.IsOkToCreate = true;
       FeatherPlacer.IsGameOver = false;
       FeatherPlacer.SpawnCoroutine = null;
       MailPlacer.IsOkToCreate = true;
       MailPlacer.IsGameOver = false;
       MailPlacer.SpawnCoroutine = null;
   }
   private void StartGame()
   {
       UI.StartGame();
       UpdateSpawnRates();
       EnableObstacles();
       EnablePlayerMovement();
       ProgressBar.StartMovement();
       ProgressBar.Move();
       
       // reset all values to initial
       ResetHealth();
       // reset score to 0
   }


   private void ResetHealth()
   {
       HealthDisplay.Health = 3f; 
       HealthDisplay.UpdateHealthDisplay();
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
      FeatherPlacer.UpdateSpawnRates();
      MailPlacer.UpdateSpawnRates();
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
