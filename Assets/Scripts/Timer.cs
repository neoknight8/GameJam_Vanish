using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void TimerStoppedHandler();
public delegate void TimerChangedHandler(int seconds);
public class Timer : SingletonMonoBehaviour<Timer>{
    TimerChangedHandler onTimerChanged;
    TimerStoppedHandler onTimerStopped;
    int seconds;

    public void SetTime(int _seconds){
        seconds = _seconds;
    }

    public void StartCount(){
        StartCoroutine(Count());
    }

    public void SetTimerChangedHandler(TimerChangedHandler handler){
        onTimerChanged = handler;
    }

    public void SetTimerStoppedHandler(TimerStoppedHandler handler){
        onTimerStopped = handler;
    }

    IEnumerator Count(){
        while(seconds > 0){
            yield return new WaitForSeconds(1f);
            seconds--;
            onTimerChanged(seconds);
        }
        onTimerStopped();
    }
}
