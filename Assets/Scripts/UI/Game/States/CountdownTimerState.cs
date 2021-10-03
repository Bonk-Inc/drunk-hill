using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountdownTimerState : PdaState
{
    [SerializeField]
    private GameObject countdownTimer;

    [SerializeField]
    private TextMeshProUGUI timer;

    [SerializeField] 
    private int countFrom;
    
    private int timeRemaining;

    public override void Enter()
    {
        timeRemaining = countFrom;
        countdownTimer.SetActive(true);
        
        StartCoroutine("Countdown");
        
        Leave();
    }

    public override void Leave()
    {
        countdownTimer.SetActive(false);
    }

    private IEnumerator Countdown()
    {
        while (timeRemaining > 0)
        {
            DisplayTime();
            timeRemaining--;
            
            yield return new WaitForSecondsRealtime(1);
        }
    }

    private void DisplayTime()
    {
        timer.text = timeRemaining.ToString();
    }
}
