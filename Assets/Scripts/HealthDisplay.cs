using UnityEngine;


public class HealthDisplay : MonoBehaviour
{
    public Game Game;
    public UI UI;
  
    public float Health = GameParameters.ChuckHealth;


    public void DecreaseHealth()
    {
        Health--;
        if (Health == 0f)
            Game.GameOver();
        UI.UpdateHealthDisplay();
    }


    public void CheckIfDead(Collider2D Chuck)
    {
        if (Health == 0f)
        {
            Destroy(Chuck.gameObject);
          
        }
    }
}