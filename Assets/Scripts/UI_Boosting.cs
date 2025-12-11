using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI_Boosting : MonoBehaviour
{
    public Game Game;

    public int Boost = 0;

    public Sprite EmptyBoostSprite;
    public Sprite OneBoostSprite;
    public Sprite TwoBoostSprite;
    public Sprite ThreeBoostSprite;
    public Sprite FourBoostSprite;
    public Sprite FiveBoostSprite;
    
    public GameObject BoostReadyText;
    public SpriteRenderer BoostSpriteRenderer;

    public float GetBoost()
    {
        return Boost;
    }
    public void UpdateBoostDisplay()
    {
        switch (Boost)
        {
            case 5:
                BoostSpriteRenderer.sprite = FiveBoostSprite;
                break;
            case 4:
                BoostSpriteRenderer.sprite = FourBoostSprite;
                break;
            case 3:
                BoostSpriteRenderer.sprite = ThreeBoostSprite;
                break;
            case 2:
                BoostSpriteRenderer.sprite = TwoBoostSprite;
                break;
            case 1:
                BoostSpriteRenderer.sprite = OneBoostSprite;
                break;
            default:
                BoostSpriteRenderer.sprite = EmptyBoostSprite;
                break;
        }
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
