using UnityEngine;

public class ArrangeBlocksPortal2 : ArrangeBlocks
{
    public Transform rect0;
    public Transform rect1;
    public Transform rect2;
    public Transform p0;
    public Transform p1;
    public float topY = 5f;  // The Y coordinate of the topmost point
    public float totalHeight = 10f; // Total height within which to space them

    void Start()
    {
        if (rect0 == null || rect1 == null || rect2 == null)
        {
            Debug.LogError("Assign all rectangles in the Inspector.");
            return;
        }
        Arrange(new Transform[] { rect0, rect1, rect2 },
            new Transform[] { p0, p1 }, totalHeight, topY);
    }
}
