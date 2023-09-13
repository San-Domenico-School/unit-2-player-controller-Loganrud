using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/************************************************************************
* This class is a component of the Scorekeeper GameObject, an in-world 
* UI Canvas.  It is designed to keeps track of and display the score for
* the game.  Functionalities are listed above each method declaration
************************************************************************/
public class Scorekeeper : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreboardText;  //Reference to the Scoreboard TextMeshProUGUI GameObject
    private float score;                                      //Player's current score
    private int penalty = 10;                                 //Penalty for running into an obstacle

    public static Scorekeeper Instance;                       //This script has a public static
                                                              //reference to itself so that other scripts can access it
                                                              //from anywhere without needing to find a reference to it

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


    //Inputs vertical input value received from the playerController script to an exponential
    //function whose values range from 0.00 to 0.35 which is then added to the score before
    //calling the DisplayScore method
    public void AddToScore(float inputFromPlayer)
    {
        // Calculate the score to add using an exponential function.
        float pointsToAdd = Mathf.Clamp01(inputFromPlayer) * 0.35f;
        score += pointsToAdd;

        // Call the DisplayScore method to update the UI.
        DisplayScore();
    }

    //Subtracts penalty from the score, ensuring it doesn't go below zero.
    public void SubtractFromScore()
    {
        // Subtract the penalty from the score.
        score -= penalty;
        if (score < 0)
        {
            score = 0;
        }
    }

    // Display the score as an integer on the UI.
    public void DisplayScore()
    {
        // Round the score to the nearest integer and display it.
        int roundedScore = Mathf.RoundToInt(score);
        scoreboardText.text = "Score:" + roundedScore.ToString();
    }
}
