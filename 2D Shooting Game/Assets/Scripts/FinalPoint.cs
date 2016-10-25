/*
 ScoreKeeper.cs
 Author:Michael Jimma
 Last Modified by: Michael Jimma
 Date last Modified 206-10-24
 Program description: This program gets the final score point from ScoreKeeper and update the score text in GameOver scene
 */

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FinalPoint : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
        Text scoreText = GetComponent<Text>();

        scoreText.text = ScoreKeeper.point.ToString();

        ScoreKeeper.Reset();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
