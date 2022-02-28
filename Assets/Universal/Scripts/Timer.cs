using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{

    public float currentTime;
    public float bestTime;
    public bool isTiming = false;

    private void Start()
    {
        StartTimer();
    }
    void Update()
    {
        if (isTiming)
        {
            currentTime += Time.deltaTime;
        }
    }

/// <summary>
/// Initialise at 0 and start timing
/// </summary>
    public void StartTimer()
    {
        isTiming = true;
        currentTime = 0f;
    }
    /// <summary>
    /// Resume the timer
    /// </summary>
    public void ResumeTimer()
    {
        isTiming = true;
    }

    /// <summary>
    /// Pause the timer
    /// </summary>
    public void PauseTimer()
    {
        isTiming = false;
    }

    /// <summary>
    /// Gets current time of timer
    /// </summary>
    /// <returns> Current value of timer </returns>
    public float GetTime()
    {
        return currentTime;
    }

    public bool IsTiming()
    {
        return isTiming;
    }
}
