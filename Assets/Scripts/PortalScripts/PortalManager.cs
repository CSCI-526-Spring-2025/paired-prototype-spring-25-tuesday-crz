using System.Collections.Generic;
using UnityEngine;

public static class PortalManager
{
    private static Dictionary<int, Vector3> portalCoordinates = new Dictionary<int, Vector3>();
    private const float yCoordinate = 3.821555f;
    private const float zCoordinate = -0.03138559f;

    public static void AddPortal(int portalID, float xCoordinate)
    {
       
        portalCoordinates.Add(portalID, new Vector3(xCoordinate, yCoordinate, zCoordinate));
    }

    public static Vector3 GetPortalX(int portalID)
    {
        if (portalCoordinates.TryGetValue(portalID, out Vector3 coordinate))
        {
            return coordinate;
        }
        else
        {
            Debug.LogWarning("Portal ID not found.");
            return new Vector3(0, 0, 0);
        }
    }
}
