using UnityEngine;

public class Stocks : MonoBehaviour
{
    public float initialPrice = 100.0f;  // Initial stock price
    public float volatility = 2.0f;  // Volatility factor

    private LineRenderer lineRenderer;
    private float elapsedTime = 0.0f;
    private float[] stockPrices;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        stockPrices = new float[1];

        // Initialize stock prices
        stockPrices[0] = initialPrice;

        // Visualize initial stock price
        VisualizeStockPrices();
    }

    void Update()
    {
        // Simulate stock price update every second
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= 1.0f)
        {
            UpdateStockPrice();
            VisualizeStockPrices();

            elapsedTime = 0.0f;
        }
    }

    void UpdateStockPrice()
    {
        float randomFactor = Random.Range(-volatility, volatility);
        float newPrice = stockPrices[stockPrices.Length - 1] + randomFactor;

        // Resize the array to accommodate the new price
        System.Array.Resize(ref stockPrices, stockPrices.Length + 1);
        stockPrices[stockPrices.Length - 1] = newPrice;
    }

    void VisualizeStockPrices()
    {
        lineRenderer.positionCount = stockPrices.Length;

        for (int i = 0; i < stockPrices.Length; i++)
        {
            lineRenderer.SetPosition(i, new Vector3(i, stockPrices[i], 0));
        }
    }
}
