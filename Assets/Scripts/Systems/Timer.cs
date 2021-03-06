using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using UnityEngine.UI;

/// <summary>
/// This class is used to display a timer on a UI Canvas
/// Taken from https://gamedevbeginner.com/how-to-make-countdown-timer-in-unity-minutes-seconds/
/// </summary>
public class Timer : MonoBehaviour
{
    [Header("In Seconds")]public float timeRemaining = 300;
    public bool timerIsRunning = false;
    public TMP_Text timeText;
    public UnityEvent OnTimerZeroed;

    private void Start()
    {
        // Starts the timer automatically
        timerIsRunning = true;
    }
    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
                OnTimerZeroed.Invoke();
            }
        }
    }
    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}