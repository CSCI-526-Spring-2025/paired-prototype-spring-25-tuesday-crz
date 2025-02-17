using System.Collections.Generic;
using UnityEngine;

public static class PortalManager
{
    private static Dictionary<int, Vector3> portalCoordinates = new Dictionary<int, Vector3>();
    private const float yCoordinate = 3.821555f;
    private const float zCoordinate = -0.03138559f;
    private const float initialXCoordinate = -15.2729f;
    private const float leftAdjustX = -8.0f;

    public static void AddPortal(int portalID, float xCoordinate)
    {
        Debug.Log($"Adding portal {portalID} at X coordinate {xCoordinate}");
        float adjustedXCoordinate = initialXCoordinate - (xCoordinate - leftAdjustX);
        portalCoordinates.Add(portalID, new Vector3(adjustedXCoordinate, yCoordinate, zCoordinate));
    }

    public static Vector3 GetPortalX(int portalID)
    {
        if (portalCoordinates.TryGetValue(portalID, out Vector3 coordinate))
        {
            return coordinate;
        }
        else
        {
            Debug.LogWarning($"Portal ID {portalID} not found.");
            return new Vector3(initialXCoordinate, yCoordinate, zCoordinate);
        }
    }
}
