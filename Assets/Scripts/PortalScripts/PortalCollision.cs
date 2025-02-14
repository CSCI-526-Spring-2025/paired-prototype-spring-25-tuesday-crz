using UnityEngine;

public class PortalCollision : MonoBehaviour
{
    public int portalID;
    void OnTriggerExit2D(Collider2D collider)
    {
        PortalIdentifier parentScript = transform.parent.GetComponent<PortalIdentifier>();

        if (parentScript != null)
        {
            GetComponent<SpriteRenderer>().color = Color.red;
            parentScript.handleCollision(portalID);
        }
    }
}
