using UnityEngine;

public class SpawnObstacle : MonoBehaviour // Class name matches the file name
{
    public GameObject obstaclePrefab; // Assign your obstacle prefab
    public float spawnInterval = 2f; // Time between spawns
    public float obstacleSpeed = 3f; // Vertical movement speed
    public float spawnXRange = 4f; // Range for X position

    private void Start()
    {
        //InvokeRepeating(nameof(SpawnObstaclePair), 1f, spawnInterval); // Method renamed
    }

    private void SpawnObstaclePair() // Renamed method to avoid conflict
    {
        bool spawnAtTop = Random.value > 0.5f; // 50% chance to spawn at top or bottom

        float randomX = Random.Range(-spawnXRange, spawnXRange);
        float spawnY = spawnAtTop ? 6f : -6f; // Top spawn at Y=6, Bottom spawn at Y=-6

        // Instantiate obstacle
        Vector3 spawnPosition = new Vector3(randomX, spawnY, 0);
        GameObject obstacle = Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);

        // Ensure Rigidbody2D exists
        Rigidbody2D rb = obstacle.GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            rb = obstacle.AddComponent<Rigidbody2D>();
        }

        rb.gravityScale = 0; // Disable gravity
        rb.linearVelocity = spawnAtTop ? Vector2.down * obstacleSpeed : Vector2.up * obstacleSpeed;
    }
}
