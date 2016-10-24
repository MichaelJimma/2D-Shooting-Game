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
        lifeText = GetComponent<Text>();
        Reset();
    }

    public void Life(int lifeValue)
    {
        life -= lifeValue;
        lifeText.text = life.ToString();
    }

    public void Reset()
    {
        life = 5;
        lifeText.text = life.ToString();
    }
}
