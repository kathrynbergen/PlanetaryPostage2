using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class QuickTimeEvent : MonoBehaviour
{
    public ProgressBarIcon ProgressBarIcon;
    public bool IsInQTE = false;

    public Text QTEText;
    public Text QTETextProgress;

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
            StartCoroutine(Wait());
        }
        else
        {
            QTEText.text = "Package Launch Success!";
            QTETextProgress.text = "+1000 Points!";
            StartCoroutine(Wait());
            
        }
            
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3f);
        QTEText.enabled = false;
        QTETextProgress.enabled = false;
        ProgressBarIcon.StartMovement();
        ProgressBarIcon.Move();
    }
}
