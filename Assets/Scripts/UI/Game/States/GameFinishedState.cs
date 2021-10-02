using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFinishedState : PdaState
{
    [SerializeField]
    private GameObject gameFinishedUiGobj;

    private float timeScaleOnEnter = 1;

    public override void Enter()
    {
        timeScaleOnEnter = Time.timeScale;
        Time.timeScale = 0;
        gameFinishedUiGobj.SetActive(true);
    }

    public override void Leave() { }

    private void OnDestroy() {
        Time.timeScale = timeScaleOnEnter;
    }
}
