using UnityEngine;

public class HealthDisplay : MonoBehaviour
{
    public SpriteRenderer HealthSpriteRenderer;
    
    public Sprite EmptyHealthSprite;
    public Sprite OneHealthSprite;
    public Sprite TwoHealthSprite;
    public Sprite ThreeHealthSprite;
    
    private float Health = GameParameters.ChuckHealth;

    public void DecreaseHealth()
    {
        if (Health == 3f)
        {
            Health--;
            HealthSpriteRenderer.sprite = TwoHealthSprite;
        }
        else if (Health == 2f)
        {
            Health--;
            HealthSpriteRenderer.sprite = OneHealthSprite;
        }
        else if (Health == 1f)
        {
            Health--;
            HealthSpriteRenderer.sprite = EmptyHealthSprite;
        }
    }

    public void CheckIfDead(Collider2D Chuck)
    {
        if (Health == 0f)
        {
            Destroy(Chuck.gameObject);
        }
    }
}
