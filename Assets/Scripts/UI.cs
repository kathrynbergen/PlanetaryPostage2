using UnityEngine;


public class UI : MonoBehaviour
{
    public HealthDisplay HealthDisplay;
    public CanvasGroup StartScreenCanvasGroup;
    public CanvasGroup GameOverCanvasGroup;
  
    public SpriteRenderer HealthSpriteRenderer;
  
    public Sprite EmptyHealthSprite;
    public Sprite OneHealthSprite;
    public Sprite TwoHealthSprite;
    public Sprite ThreeHealthSprite;
    
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


    public void UpdateHealthDisplay()
    {
        switch (HealthDisplay.Health)
        {
            case 3f:
                HealthSpriteRenderer.sprite = ThreeHealthSprite;
                break;
            case 2f:
                HealthSpriteRenderer.sprite = TwoHealthSprite;
                break;
            case 1f:
                HealthSpriteRenderer.sprite = OneHealthSprite;
                break;
            default:
                HealthSpriteRenderer.sprite = EmptyHealthSprite;
                break;
        }
    }
}