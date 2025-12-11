using UnityEngine;

public class AutoScrollParallax : MonoBehaviour
{
    [SerializeField] private float scrollSpeed = 2f;
    [SerializeField] private float parallaxMultiplier = 1f;
    
    void Update()
    {
        // Move the layer to the left continuously
        transform.position += Vector3.left * scrollSpeed * parallaxMultiplier * Time.deltaTime;
    }
}