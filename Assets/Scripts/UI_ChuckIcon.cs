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
    
    void Start()
    {
        IconRenderer.sprite = NormalIcon;
    }

    public void ReturnToNormalIcon()
    {
        IconRenderer.sprite = NormalIcon;
    }

    public void MakeHappyIcon()
    {
        IconRenderer.sprite = HappyIcon;
        StartCoroutine(ShootingTimer());
    }

    public void MakeSadIcon()
    {
        IconRenderer.sprite = SadIcon;
        StartCoroutine(ShootingTimer());
    }

    IEnumerator ShootingTimer()
    {
        yield return new WaitForSeconds(GameParameters.ChuckShootingIconDuration);
        ReturnToNormalIcon();
    }

    public void MakeDeadIcon()
    {
        IconRenderer.sprite = Dead;
    }

    public void MakeBoostingIcon()
    {
        IconRenderer.sprite = Boosting;
    }

    public void DamageIcon()
    {
        IconRenderer.sprite = Damaged;
        StartCoroutine(DamageIconTimer());
    }

    IEnumerator DamageIconTimer()
    {
        yield return new WaitForSeconds(GameParameters.ChuckDamageIconDuration);
        ReturnToNormalIcon();
    }
}
