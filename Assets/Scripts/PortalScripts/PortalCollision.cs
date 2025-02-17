using UnityEngine;

public class PortalCollision : MonoBehaviour
{
    public int portalID;
    PortalIdentifier parentScript;

    private void Start()
    {
        parentScript = transform.parent.GetComponent<PortalIdentifier>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (parentScript != null)
        {
            if(portalID == parentScript.correctPortalID)
            {
                GetComponent<SpriteRenderer>().color = Color.green;
            }
            else
            {
                GetComponent<SpriteRenderer>().color = Color.red;

            }
        }
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        if (parentScript != null)
        {
            GetComponent<SpriteRenderer>().color = Color.grey;
            parentScript.handleCollision(portalID);
        }
    }
}
