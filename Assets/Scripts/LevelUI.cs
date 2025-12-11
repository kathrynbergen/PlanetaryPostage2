using UnityEngine;
using UnityEngine.UI;

public class LevelUI : MonoBehaviour
{
    public Text ScoreText;
    
    // displays the player's score-- affected by collecting letters & feathers + delivering packages
    public void SetScoreText(int score)
    {
        ScoreText.text = "Score: " + score;
    }

    public void ShowHealthBar()
    {
        
    }
    
    public void ShowProgressBar()
    {
        
    }

    public void ShowBoostBar()
    {
        
    }

    public void ShowChuckEmote()
    {
        
    }

    public void ShowParryCoolDown()
    {
        
    }
}
