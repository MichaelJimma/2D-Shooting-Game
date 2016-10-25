/*
 Lifekeeper.cs
 Author:Michael Jimma
 Last Modified by: Michael Jimma
 Date last Modified 206-10-24
 Program description: This class keeps track the life of the player object
 */

using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class LifeKeeper : MonoBehaviour
{

    public int life = 5;
    private Text lifeText;

    void Start ()
    {
        //Gets the text component which will display the life level
        lifeText = GetComponent<Text>();
        Reset();
    }

    public void Life(int lifeValue)
    {
        //subtracts the plyer's life by lifeValue (1 is by default)
        life -= lifeValue;
        lifeText.text = life.ToString();//updates the text with the current life value
    }

    public void Reset()
    {
        //resets the players life value
        life = 5;
        lifeText.text = life.ToString();
    }
}
