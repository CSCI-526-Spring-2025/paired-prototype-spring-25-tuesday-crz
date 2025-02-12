using UnityEngine;

public class PortalIdentifier : MonoBehaviour
{
    public int portalID;
    public Transform[] movable;

    void Start()
    {
        PortalManager.AddPortal(portalID, transform.position.x);
    }

    public void moveToPreviousPortal()
    {
        // Get random integer from 0 to portalID
        int prevPortalID = Random.Range(0, portalID);

        // Move to that position
        foreach (Transform obj in movable)
        {
            Debug.Log($"Moving object to previous portal. {prevPortalID}");
            obj.position = PortalManager.GetPortalX(prevPortalID);
        }
    }
}

