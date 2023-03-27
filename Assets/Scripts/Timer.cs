using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    #region Inspector variables

    [SerializeField] private float timer;

    #endregion Inspector variables

    #region private variables

    private Coroutine timerCoroutine;
    private Action actionOnTimerFinish;

    #endregion private variables

    #region public functions

    public void AddActionOnTimerFinish(Action action)
    {
        actionOnTimerFinish += action;
    }

    public void Restart()
    {
        if (timerCoroutine != null)
        {
            StopMyCoroutine(); 
        }
        StartTimer();
    }

    public void StartTimer()
    {
        if (timerCoroutine == null)
        {
            timerCoroutine = StartCoroutine(TimerAction());
        }
    }

    #endregion public functions

    #region private functions

    private void StopMyCoroutine()
    {
        StopCoroutine(timerCoroutine);
        timerCoroutine = null;
    }
    
    private IEnumerator TimerAction()
    {
        yield return new WaitForSeconds(timer);
        actionOnTimerFinish.Invoke();
    }

    #endregion private functions
}
