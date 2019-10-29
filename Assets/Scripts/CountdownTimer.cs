using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer
{
    public float totalTime;
    private float timeHolder;
    private bool once = false;
    public bool startTimer = false;
    public bool expired;
    public Text text;

    public void Start()
    {
        timeHolder = totalTime;
    }

    public void reset()
    {
        totalTime = timeHolder;
        text.text = Mathf.RoundToInt(totalTime).ToString();
        startTimer = false;
        expired = false;
    }

    public void startCountdown()
    {
        startTimer = true;
    }

    public void stopCountdown()
    {
        startTimer = false;
    }

    public void Update()
    {
        if (totalTime > 0 && startTimer)
        {
            totalTime -= Time.deltaTime;
            text.text = Mathf.RoundToInt(totalTime).ToString();
        }
        if (totalTime <= 0 && !once)
        {
            expired = true;
            once = true;
            text.text = "0";
            Debug.Log("Switch");
        }
    }
}
