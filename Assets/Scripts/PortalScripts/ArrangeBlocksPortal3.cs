using UnityEngine;

public class ArrangeBlocksPortal3 : ArrangeBlocks
{
    public Transform rect0;
    public Transform rect1;
    public Transform rect2;
    public Transform rect3;
    public Transform p0;
    public Transform p1;
    public Transform p2;
    public Transform symbol0;
    public Transform symbol1;
    public Transform symbol2;
    public float topY = 5f;  // The Y coordinate of the topmost point
    public float totalHeight = 8.56f; // Total height within which to space them

    void Start()
    {
        if (rect0 == null || rect1 == null || rect2 == null || rect3 == null)
        {
            Debug.LogError("Assign all rectangles in the Inspector.");
            return;
        }
        Arrange(new Transform[] { rect0, rect1, rect2, rect3 },
            new Transform[] { p0, p1, p2 },
            new Transform[] { symbol0, symbol1, symbol2 },
            totalHeight, topY);
    }
}
