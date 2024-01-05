using UnityEngine;

public class Stocks : MonoBehaviour
{
    public float initialPrice = 100.0f;  // Initial stock price
    public float volatility = 0.02f;     // Volatility factor (adjust as needed)

    private float currentPrice;
    private LineRenderer lineRenderer;
    private float timer = 0.0f;

    void Start()
    {
        currentPrice = initialPrice;
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 0;
    }

    void Update()
    {
        // Update stock price every second of game time
        if (timer >= 1.0f)
        {
            UpdateStockPrice();
            UpdateLineRenderer();
            timer = 0.0f;
        }

        timer += Time.deltaTime;
    }

    void UpdateStockPrice()
    {
        // Simulate random fluctuations in stock price
        float randomFactor = Random.Range(-volatility, volatility);
        currentPrice += currentPrice * randomFactor;

        // Ensure the stock price stays within reasonable limits
        currentPrice = Mathf.Clamp(currentPrice, 1.0f, float.MaxValue);

        Debug.Log("Current Stock Price: $" + currentPrice.ToString("F2"));
    }

    void UpdateLineRenderer()
    {
        // Add the current stock price to the line renderer
        int pointCount = lineRenderer.positionCount;
        lineRenderer.positionCount = pointCount + 1;
        lineRenderer.SetPosition(pointCount, new Vector3(timer, currentPrice, 0));
    }
}
