using UnityEngine;

public class ChuckAnimator : MonoBehaviour
{
    Animator Anim;
    public SpriteRenderer SpriteRenderer;
    public KeyboardInput KeyboardInput; 
    public Chuck Chuck;

    public string isParryingName;
    public bool isParryingValue;
    
    public string isPulsingName;
    public bool isPulsingValue;

    public string isBoostingName;
    public bool isBoostingValue;
    
    
    // This class will manage Chuck's Animations

    void Start()
    {
        if (SpriteRenderer == null)
            SpriteRenderer = GetComponent<SpriteRenderer>();

        if (Anim == null)
            Anim = GetComponent<Animator>();

        if (KeyboardInput == null)
            KeyboardInput = GetComponent<KeyboardInput>();
    }

    public void NormalAnim()
    {
        StopParryingAnim();
        StopBoostingAnim();
        StopPulsingAnim();
    }
    
    public void StartParryingAnim()
    {
        Anim.SetBool(isParryingName, true);
    }

    public void StopParryingAnim()
    {
        Anim.SetBool(isParryingName, false);
    }

    public void StartBoostingAnim()
    {
        Anim.SetBool(isBoostingName, true);
    }

    public void StopBoostingAnim()
    {
        Anim.SetBool(isBoostingName, false);
    }

    public void StartPulsingAnim()
    {
        Anim.SetBool(isPulsingName, true);
    }

    public void StopPulsingAnim()
    {
        Anim.SetBool(isPulsingName, false);
    }
    
    
}
