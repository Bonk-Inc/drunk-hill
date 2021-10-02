using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverState : PdaState
{

    [SerializeField]
    private GameObject gameOverUiGobj;

    private float timeScaleOnEnter = 1;

    public override void Enter()
    {
        timeScaleOnEnter = Time.timeScale;
        Time.timeScale = 0;
        gameOverUiGobj.SetActive(true);
    }

    public override void Leave() { }

    private void OnDestroy() {
        Time.timeScale = timeScaleOnEnter;
    }
}
