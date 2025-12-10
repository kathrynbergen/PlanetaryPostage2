using UnityEngine;

public class ChuckAnimator : MonoBehaviour
{
    public Animator Animator;
    public SpriteRenderer SpriteRenderer;
    public KeyboardInput KeyboardInput;
    
    public Chuck Chuck;
    
    // This class will manage Chuck's Animations

    private void InitializeComponents()
    {
        if (SpriteRenderer == null)
            SpriteRenderer = GetComponent<SpriteRenderer>();

        if (Animator == null)
            Animator = GetComponent<Animator>();

        if (KeyboardInput == null)
            KeyboardInput = GetComponent<KeyboardInput>();
    }
    
    private void UpdateAnimator()
    {
        if (Animator == null)
            return;
        // check if chuck is parrying, boosting, pulsing, or shooting the package
            // if none are true/active, default to basic idle animation
        
    }
    
    public void StartParryingAnim()
    {
    }

    public void StopParryingAnim()
    {
    }

    public void StartBoostingAnim()
    {
    }

    public void StopBoostingAnim()
    {
    }

    public void StartPulsingAnim()
    {
    }

    public void StopPulsingAnim()
    {
    }
    
    
}
