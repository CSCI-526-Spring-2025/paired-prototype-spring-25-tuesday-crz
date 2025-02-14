using UnityEngine;

public class HeartWithStripe : MonoBehaviour
{
    public int points = 100;
    public float scale = 5f;  // Adjust scale for visibility
    public float stripeWidth = 0.2f;
    private LineRenderer heartRenderer;
    private LineRenderer stripeRenderer;


    void Awake()
    {
        Debug.Log("Awake: HeartWithStripe script is initializing.");
    }

    void OnEnable()
    {
        Debug.Log("OnEnable: HeartWithStripe script is enabled.");
    }

    void Start()
    {
        Debug.Log("HeartWithStripe script started!");

        // Create LineRenderer for Heart Shape
        heartRenderer = gameObject.AddComponent<LineRenderer>();
        heartRenderer.positionCount = points + 1;
        heartRenderer.startWidth = 0.1f;
        heartRenderer.endWidth = 0.1f;
        heartRenderer.useWorldSpace = false;
        heartRenderer.loop = true;
        heartRenderer.material = new Material(Shader.Find("Sprites/Default"));
        heartRenderer.material.color = Color.white;

        Vector3[] heartPositions = new Vector3[points + 1];

        for (int i = 0; i <= points; i++)
        {
            float t = Mathf.PI * 2 * i / points;
            float x = 16 * Mathf.Pow(Mathf.Sin(t), 3);
            float y = 13 * Mathf.Cos(t) - 5 * Mathf.Cos(2 * t) - 2 * Mathf.Cos(3 * t) - Mathf.Cos(4 * t);
            heartPositions[i] = new Vector3(x * scale * 0.01f, y * scale * 0.01f, 0);
        }

        heartRenderer.SetPositions(heartPositions);
        Debug.Log("Heart shape should be drawn!");

        // Create a separate GameObject for the stripe
        GameObject stripeObject = new GameObject("StripeObject");
        stripeObject.transform.SetParent(transform);

        // Add LineRenderer to StripeObject
        stripeRenderer = stripeObject.AddComponent<LineRenderer>();
        stripeRenderer.positionCount = 2;
        stripeRenderer.startWidth = stripeWidth;
        stripeRenderer.endWidth = stripeWidth;
        stripeRenderer.useWorldSpace = false;
        stripeRenderer.material = new Material(Shader.Find("Sprites/Default"));
        stripeRenderer.material.color = Color.white;

        // Stripe positions (middle of the heart)
        stripeRenderer.SetPositions(new Vector3[]
        {
            new Vector3(-0.4f * scale, 0.2f * scale, 0),
            new Vector3(0.4f * scale, 0.2f * scale, 0)
        });

        Debug.Log("Stripe should be drawn!");
    }
}
