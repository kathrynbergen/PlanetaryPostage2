using System.Collections;
using UnityEngine;

public class ChuckAnimator : MonoBehaviour
{
    Animator Anim;
    public SpriteRenderer SpriteRenderer;
    public KeyboardInput KeyboardInput; 

    public string isParryingName;
    public bool isParryingValue;
    
    public string isPulsingName;
    public bool isPulsingValue;

    public string isBoostingName;
    public bool isBoostingValue;

    public string isShootingReadyName;
    public bool isShootingValue;

    public string isShootingSuccessName;
    public bool isShootingSuccessValue;
    
    public string isShootingFailureName;
    public bool isShootingFailureValue;

    public string isDamagedName;
    public bool isDamagedValue;
    
    
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
        StopShootingReadyAnim();
        StopShootingFailureAnim();
        StopShootingSuccessAnim();
        StopDamageAnim();
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

    public void StartShootingReadyAnim()
    {
        Anim.SetBool(isShootingReadyName, true);
    }
    
    public void StopShootingReadyAnim()
    {
        Anim.SetBool(isShootingReadyName, false);
    }
    
    public void StartShootingSuccessAnim()
    {
        Anim.SetBool(isShootingSuccessName, true);
    }
    
    public void StopShootingSuccessAnim()
    {
        Anim.SetBool(isShootingSuccessName, false);
    }
    
    public void StartShootingFailureAnim()
    {
        Anim.SetBool(isShootingFailureName, true);
    }
    
    public void StopShootingFailureAnim()
    {
        Anim.SetBool(isShootingFailureName, false);
    }

    public void StartDamageAnim()
    {
        Anim.SetBool(isDamagedName, true);
    }
    
    public void StopDamageAnim()
    {
        Anim.SetBool(isDamagedName, false);
    }

}
