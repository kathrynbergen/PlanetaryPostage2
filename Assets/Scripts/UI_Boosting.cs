using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI_Boosting : MonoBehaviour
{
    public Game Game;

    public int Boost = 0;

    public Sprite[] BoostSprites = new Sprite[6];
    
    public GameObject BoostReadyText;
    public SpriteRenderer BoostSpriteRenderer;

    public float GetBoost()
    {
        return Boost;
    }

    public void ResetBoost()
    {
        Boost = 0;
        BoostSpriteRenderer.sprite = BoostSprites[Boost];
    }
    public void UpdateBoostDisplay()
    {
        BoostSpriteRenderer.sprite = BoostSprites[Boost];
    }

    public void IncreaseBoost()
    {
        if (Boost == 5)
        {
            return;
        }
        if (Boost == 4)
        {
            StartCoroutine(TextFlash());
        }
        Boost++;
        UpdateBoostDisplay();
    }

    IEnumerator TextFlash()
    {
        BoostReadyText.SetActive(true);
        yield return new WaitForSeconds(GameParameters.TextFlashInterval);
        BoostReadyText.SetActive(false);
        yield return new WaitForSeconds(GameParameters.TextFlashInterval);
        BoostReadyText.SetActive(true);
        yield return new WaitForSeconds(GameParameters.TextFlashInterval);
        BoostReadyText.SetActive(false);
        yield return new WaitForSeconds(GameParameters.TextFlashInterval);
        BoostReadyText.SetActive(true);
        yield return new WaitForSeconds(GameParameters.TextFlashIntervalLong);
        BoostReadyText.SetActive(false);
    }

    public bool UseBoost()
    {
        if (Boost == 5)
        {
            Boost = 0;
            UpdateBoostDisplay();
            return true;
        }
        return false;
    }
    
}
