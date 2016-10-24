using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    public int point = 0;
    private Text scoreText;

    void Start()
    {
        scoreText = GetComponent<Text>();
        Reset();
    }
    public void Score(int scoreValue)
    {
        point += scoreValue;
        scoreText.text = point.ToString();
    }

    public void Reset()
    {
        point = 0;
        scoreText.text = point.ToString();
    }
}
