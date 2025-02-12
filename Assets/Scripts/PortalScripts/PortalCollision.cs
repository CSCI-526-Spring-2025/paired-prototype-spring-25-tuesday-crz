using UnityEngine;

public class PortalCollision : MonoBehaviour
{
    void OnTriggerExit2D(Collider2D collider)
    {
        Debug.Log("Collision with 2D Rectangle detected!");
        GetComponent<SpriteRenderer>().color = Color.red;
        PortalIdentifier parentScript = transform.parent.GetComponent<PortalIdentifier>();

        if (parentScript != null)
        {
            // Call the method on the parent object when the collision happens
            parentScript.moveToPreviousPortal();
        }
    }
}
