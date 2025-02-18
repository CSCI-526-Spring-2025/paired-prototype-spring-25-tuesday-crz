using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public static class PortalManager
{
    private static Dictionary<int, float> portalCoordinates = new Dictionary<int, float>();
    private const float yCoordinate = 3.821555f;
    private const float zCoordinate = -0.03138559f;
    private const float initialXCoordinate = -15.2729f;
    private const float leftAdjustX = -8.0f;
    private const float initialPlayerX = -7.3f;

    public static void AddPortal(int portalID, float xCoordinate)
    {
        Debug.Log($"Adding portal {portalID} at X coordinate {xCoordinate}");
        
        // if player is to the left, adjust background to be more to the left, ie more negative
        float adjustedXCoordinate = initialXCoordinate - (xCoordinate - leftAdjustX);
        portalCoordinates.Add(portalID, adjustedXCoordinate);
    }

    public static Vector3 GetPortalX(int portalID)
    {
        float currentPlayerX = GameObject.Find("Player").transform.position.x;
        float diff = currentPlayerX - initialPlayerX;

        if (portalCoordinates.TryGetValue(portalID, out float coordinate))
        {
            float adjustedXCoordinate = coordinate + diff;
            Debug.Log($"Moving to portal {portalID} at X coordinate {adjustedXCoordinate}");
            return new Vector3(adjustedXCoordinate, yCoordinate, zCoordinate);
        }
        else
        {
            Debug.LogWarning($"Portal ID {portalID} not found.");
            return new Vector3(initialXCoordinate + diff, yCoordinate, zCoordinate);
        }
    }
}
