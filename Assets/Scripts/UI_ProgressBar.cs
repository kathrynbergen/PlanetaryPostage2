using UnityEngine;
using UnityEngine.UIElements;

public class UI_ProgressBar : MonoBehaviour
{
    public ProgressBarIcon ChuckIcon;
    private bool canMove = false;

    void Update()
    {
        if (canMove)
        {
            ChuckIcon.MoveOnBar();
        }
    }
    
    public void StartMovement()
    {
        canMove = true;
    }
    
    public void StopMovement()
    {
        canMove = false;
    }
}
