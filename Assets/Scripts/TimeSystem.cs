using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSystem : MonoBehaviour
{

    private float tickLength = 2.5f; //Lenght of a tick in seconds. Equal to one in game hour
    private GameTime gameTime;
    public bool timerActive = true;
    Coroutine timeTrackerCoroutine;

    public event EventHandler<GameTime> TickAdded;

    private void Awake()
    {
        timeTrackerCoroutine = StartCoroutine(TimeTracker());
    }

    private IEnumerator TimeTracker()
    {
        while(timerActive)
        {
            yield return new WaitForSeconds(tickLength);
            AddTick();
        }
    }

    private void AddTick()
    {
        gameTime.hour += 1;
        if(gameTime.hour == 24)
        {
            gameTime.day += 1;
            gameTime.hour = 0;
        }

        if (TickAdded != null)
        {
            TickAdded(this, gameTime);
        }
        Debug.Log("Day: " + gameTime.day + ", Hour: " + gameTime.hour);
    }

    public void StartTimer()
    {
        timeTrackerCoroutine = StartCoroutine(TimeTracker());
    }

    public void StopTimer()
    {
        StopCoroutine(timeTrackerCoroutine);
    }
}
