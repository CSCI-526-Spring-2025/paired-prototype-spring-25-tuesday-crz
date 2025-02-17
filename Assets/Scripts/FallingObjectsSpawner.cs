using System.Collections;
using UnityEngine;

public class FallingObjectsSpawner : MonoBehaviour
{
    public GameObject fallingObjectPrefab; 
    public float spawnInterval = 1.5f;
    public float spawnXRange = 10f; // Controls width of spawn area beyond 285
    public float fallSpeed = 3f; 

    private float screenHeight;

    void Start()
    {   
        Debug.Log("Spawner Script Started");
        screenHeight = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y;
        //StartCoroutine(SpawnFallingObjects());
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
        float randomX = Random.Range(285f, 285f + spawnXRange); // Ensuring X > 285
        bool spawnFromTop = Random.value > 0.5f;
        float spawnY = spawnFromTop ? screenHeight + 1f : -screenHeight - 1f;

        GameObject obj = Instantiate(fallingObjectPrefab, new Vector2(randomX, spawnY), Quaternion.identity);

        if (!obj.GetComponent<Rigidbody2D>())
            obj.AddComponent<Rigidbody2D>();

        Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        rb.linearVelocity = new Vector2(0, spawnFromTop ? -fallSpeed : fallSpeed);

        //Debug.Log($"Spawning at X: {randomX}, Y: {spawnY}");

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
