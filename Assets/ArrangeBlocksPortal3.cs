using UnityEngine;

public class ArrangeBlocksPortal3 : ArrangeBlocks
{
    public Transform rect1;
    public Transform rect2;
    public Transform rect3;
    public Transform rect4;
    public Transform p1;
    public Transform p2;
    public Transform p3;
    public float topY = 5f;  // The Y coordinate of the topmost point
    public float totalHeight = 8.56f; // Total height within which to space them

    void Start()
    {
        if (rect1 == null || rect2 == null || rect3 == null || rect4 == null)
        {
            Debug.LogError("Assign all rectangles in the Inspector.");
            return;
        }
        Arrange(new Transform[] { rect1, rect2, rect3, rect4 },
            new Transform[] { p1, p2, p3 }, totalHeight, topY);
    }
}
