using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab; // Assign your obstacle prefab in Unity
    public float spawnInterval = 2f; // Time between spawns
    public float obstacleSpeed = 5f; // Movement speed of obstacles
    public float gapSize = 10f; // Distance between top and bottom obstacles
    public float spawnXPosition = 10f; // Where obstacles spawn on the X-axis
    public float minY = -3f; // Minimum Y position for bottom obstacle
    public float maxY = 3f; // Maximum Y position for bottom obstacle

    private void Start()
    {
        InvokeRepeating(nameof(SpawnObstaclePair), 1f, spawnInterval);
    }

    void SpawnObstaclePair()
    {
        float randomY = Random.Range(minY, maxY); // Random Y position for bottom obstacle

        // Spawn Bottom Obstacle
        Vector3 bottomPosition = new Vector3(spawnXPosition, randomY, 0);
        GameObject bottomObstacle = Instantiate(obstaclePrefab, bottomPosition, Quaternion.identity);
        bottomObstacle.GetComponent<Rigidbody2D>().linearVelocity = Vector2.left * obstacleSpeed;

        // Spawn Top Obstacle (GapSize units above the bottom)
        Vector3 topPosition = new Vector3(spawnXPosition, randomY + gapSize, 0);
        GameObject topObstacle = Instantiate(obstaclePrefab, topPosition, Quaternion.identity);
        topObstacle.GetComponent<Rigidbody2D>().linearVelocity = Vector2.left * obstacleSpeed;
    }
}
