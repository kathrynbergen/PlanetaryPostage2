using UnityEngine;


public class HealthDisplay : MonoBehaviour
{
    public Game Game;
  
    public float Health = GameParameters.ChuckHealth;
    
    public Sprite EmptyHealthSprite;
    public Sprite OneHealthSprite;
    public Sprite TwoHealthSprite;
    public Sprite ThreeHealthSprite;
    
    public SpriteRenderer HealthSpriteRenderer;

    public float getHealth()
    {
        return Health;
    }
    public void UpdateHealthDisplay()
    {
        switch (Health)
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
    
    public void DecreaseHealth()
    {
        Debug.Log("Player took damage!");
        Health--;
        if (Health == 0f)
            Game.GameOver();
        UpdateHealthDisplay();
    }

    public void IncreaseHealth()
    {
        if (Health == 3f)
        {
            return;
        }
        else
        {
            Health++;
        }
    }
}