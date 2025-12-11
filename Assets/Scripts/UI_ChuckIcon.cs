using System.Collections;
using UnityEngine;

public class UI_ChuckIcon : MonoBehaviour
{
    public SpriteRenderer IconRenderer;
    public Sprite NormalIcon;
    public Sprite HappyIcon;
    public Sprite SadIcon;
    public Sprite Damaged;
    public Sprite Boosting;
    public Sprite Dead;

    public Chuck Chuck;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeChuckIcon()
    {
        // if nothing, keep normal
        // if boosting, change to boosting
        // if successful package shoot, change to happy
        // if failed package shoot, change to sad
        // if chuck gets hit, change to damaged
        // if chuck loses all health, change to dead
    }

    public void ReturnToNormalIcon()
    {
        IconRenderer.sprite = NormalIcon;
    }

    public void DamageIcon()
    {
        IconRenderer.sprite = Damaged;
        StartCoroutine(DamageIconTimer());
    }

    IEnumerator DamageIconTimer()
    {
        yield return new WaitForSeconds(GameParameters.ChuckBoostDuration);
        ReturnToNormalIcon();
    }
}
