using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class QuickTimeEvent : MonoBehaviour
{
    public ProgressBarIcon ProgressBarIcon;
    public bool IsInQTE = false;
    public HealthDisplay Health;

    public Text QTEText;
    public Text QTETextProgress;
    public Text QTETextTimer;

    public int pressesNeeded = 10;
    public float timeLimit = 5f;
    private int currentPresses = 0;
    private float timer = 0f;

    void Update()
    {
        if (!IsInQTE)
        {
            return;
        }
        QTETextTimer.text = "Time Remaining: " + (timeLimit - timer).ToString("F2");

        timer += Time.deltaTime;
        if (timer >= timeLimit)
        {
            EndQTE(false);
            return;
        }

        QTETextProgress.text = currentPresses + "/" + pressesNeeded;
        if (currentPresses >= pressesNeeded)
        {
            EndQTE(true);
        }
    }

    public void StartQTE()
    {
        IsInQTE = true;
        currentPresses = 0;
        timer = 0f;
        QTEText.enabled = true;
        QTETextProgress.enabled = true;
        QTETextTimer.enabled = true;
        QTEText.text = "Spam Space To Launch The Package Before Time Runs Out!";
        QTETextProgress.text = "0/" + pressesNeeded;
    }

    public void SpacePress()
    {
        if (!IsInQTE)
        {
            return;
        }
        currentPresses++;
    }

    void EndQTE(bool didBeatQTE)
    {
        IsInQTE = false;
        
        if (!didBeatQTE)
        {
            QTEText.text = "Package Launch Failed!";
            QTETextTimer.text = "TIME'S UP!";
            QTETextProgress.text = "-1000 Points!";
            StartCoroutine(Wait());
        }
        else
        {
            QTEText.text = "Package Launch Success!";
            QTETextTimer.text = "+1000 Points!";
            StartCoroutine(Wait());
            
        }
            
    }

    public void ForceStop()
    {
        IsInQTE = false;
        QTEText.enabled = false;
        QTETextProgress.enabled = false;
        QTETextTimer.enabled = false;
        StopAllCoroutines();
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3f);
        QTEText.enabled = false;
        QTETextProgress.enabled = false;
        QTETextTimer.enabled = false;
        ProgressBarIcon.StartMovement();
        ProgressBarIcon.Move();
    }
    
}
