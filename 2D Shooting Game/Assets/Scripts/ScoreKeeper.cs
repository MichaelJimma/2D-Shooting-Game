/*
 ScoreKeeper.cs
 Author:Michael Jimma
 Last Modified by: Michael Jimma
 Date last Modified 206-10-24
 Program description: This class keeps track of player's score
 */

using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    public static int point = 0;
    private Text scoreText;

    void Start()
    {
        //get the text object component
        scoreText = GetComponent<Text>();
        Reset();
    }
    public void Score(int scoreValue)
    {
        //add the scoreVlaue to point and update the score text 
        point += scoreValue;
        scoreText.text = point.ToString();
    }

    public static void Reset()
    {
        point = 0;
    }
}
