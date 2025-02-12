using UnityEngine;

public class ArrangeBlocksPortal2 : ArrangeBlocks
{
    public Transform rect1;
    public Transform rect2;
    public Transform rect3;
    public Transform p1;
    public Transform p2;
    public float topY = 5f;  // The Y coordinate of the topmost point
    public float totalHeight = 10f; // Total height within which to space them

    void Start()
    {
        if (rect1 == null || rect2 == null || rect3 == null)
        {
            Debug.LogError("Assign all rectangles in the Inspector.");
            return;
        }
        Arrange(new Transform[] { rect1, rect2, rect3 },
            new Transform[] { p1, p2 }, totalHeight, topY);
    }
}
