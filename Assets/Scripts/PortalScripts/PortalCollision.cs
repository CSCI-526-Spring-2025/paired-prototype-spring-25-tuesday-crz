using UnityEngine;

public class PortalCollision : MonoBehaviour
{
    public bool isCorrect = false;
    void OnTriggerExit2D(Collider2D collider)
    {
        Debug.Log("Collision with 2D Rectangle detected!");
        PortalIdentifier parentScript = transform.parent.GetComponent<PortalIdentifier>();

        if (!isCorrect && parentScript != null)
        {
            GetComponent<SpriteRenderer>().color = Color.red;
            parentScript.moveToPreviousPortal();
        }
    }
}
