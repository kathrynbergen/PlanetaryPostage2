using UnityEngine;

public class PlanetScroller : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float travelTime = 60f;
    [SerializeField] private float startPositionX = 0f;
    [SerializeField] private float endPositionX = -15f;
    
    private float elapsedTime = 0f;
    private bool isMoving = false;
    private Vector3 startPos;
    private Vector3 endPos;
    
    void Start()
    {
        startPos = new Vector3(startPositionX, transform.position.y, transform.position.z);
        endPos = new Vector3(endPositionX, transform.position.y, transform.position.z);
        transform.position = startPos;
    }
    
    public void StartMovement()
    {
        isMoving = true;
        elapsedTime = 0f;
    }
    
    public void StopMovement()
    {
        isMoving = false;
    }
    
    void Update()
    {
        if (!isMoving) return;
        
        elapsedTime += Time.deltaTime;
        float t = elapsedTime / travelTime;
        
        // Move planet from right to left over travelTime
        transform.position = Vector3.Lerp(startPos, endPos, t);
        
        // Stop when reached end
        if (t >= 1f)
        {
            isMoving = false;
            Debug.Log("Planet reached end position!");
        }
    }
}