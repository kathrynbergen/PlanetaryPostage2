using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleObjectPlacer : MonoBehaviour
{
    public GameObject ObstaclePrefab;
    
    public float minimumSecondsUntilSpawn = 1f;
    public float maximumSecondsUntilSpawn = 3f;

    public bool IsOkToCreate = false;
    public bool IsGameOver = false;
    
    // bottom and top of screen bounds
    private float minimumY = -0.85f; 
    private float maximumY = 0.25f;
    
    private List<GameObject> spawnedObstacles = new List<GameObject>();
    
    private static List<float> occupiedY = new List<float>();
    
    public Coroutine SpawnCoroutine;

    // Update is called once per frame
    void Update()
    {
        if (IsOkToCreate && SpawnCoroutine == null)
        {
            SpawnCoroutine = StartCoroutine(CountdownUntilCreation());
        }
    }

    IEnumerator CountdownUntilCreation()
    {
        IsOkToCreate = false;
        if (IsGameOver) 
            yield break;
        float secondsToWait = Random.Range(minimumSecondsUntilSpawn, maximumSecondsUntilSpawn);
        yield return new WaitForSeconds(secondsToWait);
        
        yield return TryToPlaceObstacle();
        
        IsOkToCreate = true;
        SpawnCoroutine = null;
    }

    IEnumerator TryToPlaceObstacle()
    {
        for (int attempt = 0; attempt < 50; attempt++)
        {
            float chosenY = Random.Range(minimumY, maximumY);
            
            Vector2 boxSize = new Vector2(0.75f, 0.75f); 
            Vector2 spawnPosition = new Vector2(10f, chosenY);

            Collider2D hit = Physics2D.OverlapBox(spawnPosition, boxSize, 0f);

            if (hit == null || hit.tag != "Obstacle") 
            {
                PlaceObstacle(chosenY);
                yield break;
            }
        }
        
        yield return new WaitForSeconds(0.1f);
    }

    public void PlaceObstacle(float yLocation)
    {
        GameObject newObstacle = Instantiate(ObstaclePrefab, new Vector2(GameParameters.ObstacleXSpawnCoordinate,yLocation), Quaternion.identity);
        occupiedY.Add(yLocation);
        spawnedObstacles.Add(newObstacle);
    }

    public void DestroyObstacle()
    {
        foreach (GameObject obstacle in spawnedObstacles)
        {
                Destroy(obstacle);
        }
        spawnedObstacles.Clear();
        occupiedY.Clear();

        if (SpawnCoroutine != null)
        {
            StopCoroutine(SpawnCoroutine);
            SpawnCoroutine = null;
        }
    }
}
