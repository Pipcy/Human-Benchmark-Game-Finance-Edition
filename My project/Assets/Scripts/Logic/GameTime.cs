using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class GameTime : MonoBehaviour
{

    private float elapsedTime; //the actual time elapsed since starting game, in seconds
    public TextMeshProUGUI dateText;
    public TextMeshProUGUI ageText;

    public DateTime startDate;
    public DateTime currentDate;

    public int age;

    void Start()
    {
        elapsedTime = 0f;
        startDate = new DateTime(2020, 1, 1);
        age = 18;
    }


    void Update()
    {
        elapsedTime += Time.deltaTime;
        
        //for every second is 10 day
        int elapsedDays = Mathf.FloorToInt(elapsedTime * 10);

        // Calculate the current date based on the start date and elapsed days
        currentDate = startDate.AddDays(elapsedDays);

        //age - takes the difference between starting and current year + 18
        //** the logic for now thinks birthday is on jan 1
        age = 18 + (currentDate.Year - startDate.Year);


        UpdateTimeText();
        //debug ----------------------------------------------------------------------------
            // Display the current date (you can modify this part based on your requirements)
            //Debug.Log("Current Date: " + currentDate.ToString("yyyy-MM-dd"));
    }

    //update time text on the screen
    void UpdateTimeText()
    {
        dateText.text = "Date: " + currentDate.ToString("yyyy-MM-dd");
        ageText.text = "Age: " + age.ToString();
        //Debug.Log("Age: " + (currentDate.Year - startDate.Year).ToString());
    }
}
