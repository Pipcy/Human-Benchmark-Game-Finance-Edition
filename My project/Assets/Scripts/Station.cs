using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Station : MonoBehaviour
{
    public string stationName;
    public float stationValue;
    public TextMeshProUGUI stationNameText;
    public TextMeshProUGUI stationValueText;


    void Start()
    {
        stationName = "Untitled Station";
        stationValue = 0;
    }

    
    void Update()
    {
        DisplayStationProperty();
    }

    void DisplayStationProperty()
    {
        stationNameText.text = stationName;
        stationValueText.text = "$" + stationValue.ToString();
    }
}
