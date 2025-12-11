using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ProgressBarIcon : MonoBehaviour
{
    public PlanetScroller PlanetScroller;
    public SpriteRenderer PBISpriteRenderer;
    public Sprite NormalSprite;
    public QuickTimeEvent QTE;
    public HealthDisplay HealthDisplay;

    public int planetsVisited;
    public float startPosition = 0.75f;  
    public float endPosition = 1.58f;  
    public float travelTime = 30f; 
    
    private bool isMoving = false;
    
    public void StartMovement()
    {
        isMoving = true;
    }
    
    public void StopMovement()
    {
       isMoving = false;    
    }

    public void Move()
    {
        if (isMoving)
        {
            StartCoroutine(StartMovingOnBar());
        }
    }

    IEnumerator StartMovingOnBar()
    {
        float timeOnBar = 0f;

        while (timeOnBar < travelTime)
        {
            if (HealthDisplay.getHealth() == 0)
            {
                yield break;
            }
            float t = timeOnBar/travelTime;
            float xPos = Mathf.Lerp(startPosition, endPosition, t);
                
            transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
            timeOnBar += Time.deltaTime;
            yield return null;
        }
        
        PlanetScroller.StartMovement();

        Debug.Log("Planet Reached!");
        QTE.StartQTE();
    }
    
    public void ForceStop()
    {
        isMoving = false;
        StopAllCoroutines();
    }
}
