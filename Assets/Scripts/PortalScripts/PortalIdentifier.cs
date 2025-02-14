using UnityEngine;

public class PortalIdentifier : MonoBehaviour
{
    public int portalColumnID;
    public int correctPortalID;
    public Transform[] movable;

    void Start()
    {
        PortalManager.AddPortal(portalColumnID, transform.position.x);
    }

    public void handleCollision(int collisionID)
    {
        Debug.Log($"Collision at col {portalColumnID} row {collisionID}");
        if (collisionID != correctPortalID)
        {
            // Get random integer from 0 to portalID
            int prevPortalID = Random.Range(0, portalColumnID);

            // Move to that position
            foreach (Transform obj in movable)
            {
                Debug.Log($"Moving to previous portal {prevPortalID}");
                obj.position = PortalManager.GetPortalX(prevPortalID);
            }
        }
    }
}

