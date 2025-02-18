using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene reload

public class BirdCollisionHandler : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle")) // Ensure your obstacles have the tag "Obstacle"
        {
            RestartGame();
        }
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Restart the scene
    }
}
