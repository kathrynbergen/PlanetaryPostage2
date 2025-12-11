using UnityEngine;
using System.Collections;


public class UI_ParryCooldown : MonoBehaviour
{
    public SpriteRenderer ParryMeterSpriteRenderer;
    public Chuck Chuck;
    
    public Sprite ParryCooldownEmpty;
    public Sprite ParryCooldownOne;
    public Sprite ParryCooldownTwo;
    public Sprite ParryCooldownThree;
    public Sprite ParryCooldownFour;
    public Sprite ParryCooldownReady;
    
    public GameObject ParryReadyText;

    public void StartCooldown()
    {
        StartCoroutine(ParryCooldown());
    }

    IEnumerator ParryCooldown()
    {
        ParryMeterSpriteRenderer.sprite = ParryCooldownEmpty;
        yield return new WaitForSeconds(GameParameters.ChuckParryCooldownIntervalBetweenSpriteChange);
        ParryMeterSpriteRenderer.sprite = ParryCooldownOne;
        yield return new WaitForSeconds(GameParameters.ChuckParryCooldownIntervalBetweenSpriteChange);
        ParryMeterSpriteRenderer.sprite = ParryCooldownTwo;
        yield return new WaitForSeconds(GameParameters.ChuckParryCooldownIntervalBetweenSpriteChange);
        ParryMeterSpriteRenderer.sprite = ParryCooldownThree;
        yield return new WaitForSeconds(GameParameters.ChuckParryCooldownIntervalBetweenSpriteChange);
        ParryMeterSpriteRenderer.sprite = ParryCooldownFour;
        yield return new WaitForSeconds(GameParameters.ChuckParryCooldownIntervalBetweenSpriteChange);
        ParryMeterSpriteRenderer.sprite = ParryCooldownReady;
        
        Chuck.setCanParrying(true);
        ParryReadyText.SetActive(true);
        yield return new WaitForSeconds(GameParameters.TextFlashInterval);
        ParryReadyText.SetActive(false);
        yield return new WaitForSeconds(GameParameters.TextFlashInterval);
        ParryReadyText.SetActive(true);
        yield return new WaitForSeconds(GameParameters.TextFlashInterval);
        ParryReadyText.SetActive(false);
        yield return new WaitForSeconds(GameParameters.TextFlashInterval);
        ParryReadyText.SetActive(true);
        yield return new WaitForSeconds(GameParameters.TextFlashIntervalLong);
        ParryReadyText.SetActive(false);
    }
}
