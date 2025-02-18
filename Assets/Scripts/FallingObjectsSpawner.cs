using System.Collections;
using UnityEngine;

public class FallingObjectsSpawner : MonoBehaviour
{
    public GameObject fallingObjectPrefab; 
    public float spawnInterval = 4f;
    public float spawnXRange = 5f; // Controls width of spawn area beyond 285
    public float fallSpeed = 0.2f; 

    private float screenHeight;

    void Start()
    {   
        Debug.Log("Spawner Script Started");
        screenHeight = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y;
        StartCoroutine(SpawnFallingObjects());
    }

    IEnumerator SpawnFallingObjects()
    {
        while (true)
        {
            SpawnObject();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnObject()
    {
        float randomX = Random.Range(125f, 125f + spawnXRange); // Ensuring X > 285
        float spawnY = screenHeight + 1f; // Always spawn from the top

        GameObject obj = Instantiate(fallingObjectPrefab, new Vector2(randomX, spawnY), Quaternion.identity);

        if (!obj.GetComponent<Rigidbody2D>())
            obj.AddComponent<Rigidbody2D>();

        Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
        rb.gravityScale = 1; // Enable natural gravity
        rb.linearVelocity = Vector2.zero; // Remove any preset velocity

        // ✅ Add SpriteRenderer for visibility
        SpriteRenderer sr = obj.GetComponent<SpriteRenderer>();
        if (sr == null)
        {
            sr = obj.AddComponent<SpriteRenderer>();
            sr.color = Color.red; // Debugging color
        }

        // ✅ Set sorting order to make sure it's visible
        sr.sortingOrder = 10;
    }
}
