using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/************************************************************************
* This class is a component of the Timer GameObject, an in-world 
* UI Canvas.  It is designed to keeps track of and display the time for
* the game.  Functionalities are listed above each method declaration
************************************************************************/

public class Time : MonoBehaviour
{
    public static Time Instance;                       //This script has a public static
                                                       //reference to itself so that other scripts can access it
                                                       //from anywhere without needing to find a reference to it
    public TextMeshProUGUI timerText;                             // Reference to a Text component where you want to display the timer.
    private bool isTimerRunning = true;
    private float elapsedTime = 0f;


    //Called during the initialization of a script/component.
    void Awake()
    {
        //This is a common approach to handling a class with a reference to itself.
        //If instance variable doesn't exist, assign this object to it
        if (Instance == null)
            Instance = this;
        //Otherwise, if the instance variable does exist, but it isn't this object, destroy this object.
        //This is useful so that we cannot have more than one GameManager object in a scene at a time.
        else if (Instance != this)
            Destroy(this);
    }
    private void Update()
    {
        if (isTimerRunning)
        {
            //elapsedTime += 
            UpdateTimerDisplay();
        }
    }

    private void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);
        int milliseconds = Mathf.FloorToInt((elapsedTime * 1000) % 1000);

        timerText.text = string.Format("{0:00}:{1:00}.{2:000}", minutes, seconds, milliseconds);
    }
}