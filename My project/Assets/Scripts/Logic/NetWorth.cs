using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NetWorth : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI netWorthDisplay;
    public int netWorth;

    void Start()
    {
        netWorth = 0;
    }

   
    void Update()
    {
        DisplayNetWorth();
    }

    void DisplayNetWorth()
    {
        netWorthDisplay.enabled = true;
        netWorthDisplay.text = "NetWorth: $" + netWorth.ToString();
    }
}
