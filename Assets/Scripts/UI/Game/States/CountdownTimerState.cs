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
    private AudioSource countdownAudio;
    
    [SerializeField] 
    private int countFrom;

    private int timeRemaining;

    public override void Enter()
    {
        timeRemaining = countFrom;
        countdownTimer.SetActive(true);
        
        Time.timeScale = 0;

        StartCoroutine("Countdown");
    }

    public override void Leave()
    {
        countdownTimer.SetActive(false);
        Time.timeScale = 1;
    }

    private IEnumerator Countdown()
    {
        while (timeRemaining > 0)
        {
            DisplayTime();
            countdownAudio.Play();
            timeRemaining--;
            
            yield return new WaitForSecondsRealtime(1);
        }
        
        Machine.PopState();
    }

    private void DisplayTime()
    {
        timer.text = timeRemaining.ToString();
    }
}
