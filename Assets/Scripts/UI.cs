using UnityEngine;


public class UI : MonoBehaviour
{
    public HealthDisplay HealthDisplay;
    public CanvasGroup StartScreenCanvasGroup;
    public CanvasGroup GameOverCanvasGroup;
    
    
    public void StartGame()
    {
        CanvasGroupDisplayer.Hide(StartScreenCanvasGroup);
        CanvasGroupDisplayer.Hide(GameOverCanvasGroup);
    }


    public void GameOver()
    {
        CanvasGroupDisplayer.Show(GameOverCanvasGroup);
    }


    public void ReturnToMenu()
    {
        CanvasGroupDisplayer.Show(StartScreenCanvasGroup);
        CanvasGroupDisplayer.Hide(GameOverCanvasGroup);
    }

    public void ShowHealth()
    {
        HealthDisplay.UpdateHealthDisplay();
    }
}