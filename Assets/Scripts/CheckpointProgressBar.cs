using UnityEngine;
using UnityEngine.UI;

public class CheckpointProgressBar : MonoBehaviour
{
    public Transform player;          // Player reference
    public Transform[] checkpoints;   // Array of checkpoints
    private Slider slider;            // Reference to the UI Slider
    private int currentCheckpoint = 0; // Keeps track of the reached checkpoint

    void Start()
{
    slider = GetComponent<Slider>();

    // Force-enable Slider
    slider.gameObject.SetActive(true);
    Debug.Log("Progress Bar is enabled");

    // Ensure there are checkpoints
    if (checkpoints.Length > 0)
    {
        slider.maxValue = checkpoints.Length;
        Debug.Log("Max checkpoints set to: " + checkpoints.Length);

        // Log each checkpoint's position
        for (int i = 0; i < checkpoints.Length; i++)
        {
            Debug.Log("Checkpoint " + (i + 1) + " Position: " + checkpoints[i].position.x);
        }
    }
    else
    {
        Debug.LogWarning("No checkpoints assigned to the progress bar!");
    }

    // Log initial values
    Debug.Log("Initial Slider Value: " + slider.value);
}


    void Update()
    {
        if (player == null)
        {
            Debug.LogError("Player Transform is not assigned!");
            return;
        }

        // Track player position
        Debug.Log("Player Position: " + player.position.x);

        // Check if the player has passed any new checkpoints
        for (int i = 0; i < checkpoints.Length; i++)
        {
            if (player.position.x >= checkpoints[i].position.x)
            {
                Debug.Log("Player reached checkpoint " + (i + 1));
                currentCheckpoint = i + 1;
            }
        }



        // Update the progress bar value
        slider.value = currentCheckpoint;
        Debug.Log("Slider Value Updated: " + slider.value);
    }
}
