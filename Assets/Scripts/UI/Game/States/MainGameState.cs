using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameState : PdaState
{

    private float menuLastFrame = 0;

    [SerializeField]
    private PauseGameState pauseGameState;

    private MenuOpenCheck menuInput = new MenuOpenCheck();

    public override void Enter()
    {
        menuInput.Update();
        Time.timeScale = 1;
    }

    public override void Resume()
    {
        menuInput.Update();
    }

    public override void Leave() {}

    public override void Reason()
    {
        if(menuInput.Check()){
            Machine.PushState(pauseGameState);
        } 
    }
}
