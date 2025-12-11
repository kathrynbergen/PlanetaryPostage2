using UnityEngine;

public class StarLooper : MonoBehaviour
{
    [SerializeField] private float resetPositionX = 15f;
    [SerializeField] private float startPositionX = -15f;
    
    void Update()
    {
        // If star goes too far left, move it back to the right
        if (transform.position.x < startPositionX)
        {
            Vector3 newPos = transform.position;
            newPos.x = resetPositionX;
            // Randomize Y position slightly for variety
            newPos.y = Random.Range(-5f, 5f);
            transform.position = newPos;
        }
    }
}