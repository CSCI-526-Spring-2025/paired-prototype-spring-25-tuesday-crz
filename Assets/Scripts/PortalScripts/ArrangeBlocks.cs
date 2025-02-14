using UnityEngine;

public abstract class ArrangeBlocks : MonoBehaviour
{
    [SerializeField] private float _padding = 0.25f;
    public bool useDefaultBlockHeight = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Arrange(Transform[] rects, Transform[] portals, float totalHeight, float topY)
    {
        // Get size of rects array
        int n = rects.Length;

        // Create heights array
        float[] heights = new float[n];

        if(useDefaultBlockHeight)
        {
            for (int i = 0; i < n; i++)
            {
                heights[i] = totalHeight/2f/(float)n;
                rects[i].localScale = new Vector3(rects[i].localScale.x, heights[i], rects[i].localScale.z);
            }
        }

        // Get individual and total heights
        float totalRectsHeight = 0f; 
        for (int i = 0; i < n; i++)
        {
            heights[i] = rects[i].GetComponent<SpriteRenderer>().bounds.size.y;
            totalRectsHeight += heights[i];
        }

        float spacing = (totalHeight - totalRectsHeight) / (float)(n-1);

        // Arrange the blocks
        float currentY = topY - heights[0] / 2f;
        rects[0].position = new Vector3(rects[0].position.x, currentY, rects[0].position.z);
        for (int i = 1; i < n; i++)
        {
            // Set portal
            currentY -= (heights[i - 1] / 2f + spacing / 2f);
            portals[i-1].localScale = new Vector3(transform.localScale.x, spacing - _padding, transform.localScale.z);
            portals[i-1].position = new Vector3(portals[i-1].position.x, currentY, portals[i-1].position.z);

            // Set block
            currentY -= (spacing / 2f + heights[i] / 2f);
            rects[i].position = new Vector3(rects[i].position.x, currentY, rects[i].position.z);
        }
    }
}
