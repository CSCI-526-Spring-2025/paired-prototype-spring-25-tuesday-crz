using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;  // Reference to the player's transform
    public float smoothSpeed = 0.125f; // Adjust for smoothness
    public float fixedY = 5f; // Fixed Y position
    public float fixedZ = -10f; // Fixed Z position

    void LateUpdate()
    {
        if (player != null)
        {
            // Keep Y and Z fixed, only update X
            Vector3 desiredPosition = new Vector3(player.position.x, fixedY, fixedZ);
            transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        }
    }
}
