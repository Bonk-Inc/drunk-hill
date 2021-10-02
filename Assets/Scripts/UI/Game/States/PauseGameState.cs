using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGameState : PdaState
{

    [SerializeField]
    private GameObject pauseGameMenu;

    private float timeScaleAtEnter = 0;

    private MenuOpenCheck menuInput = new MenuOpenCheck();

    public override void Enter()
    {
        menuInput.Update();
        timeScaleAtEnter = Time.timeScale;
        Time.timeScale = 0;
        pauseGameMenu.SetActive(true);
    }

    public override void Resume()
    {
        menuInput.Update();
    }

    public override void Leave()
    {
        Time.timeScale = timeScaleAtEnter;
        pauseGameMenu.SetActive(false);
    }

    public override void Reason()
    {
        if(menuInput.Check()){
            Unpause();
        } 
    }

    public void Unpause(){
        Machine.PopState();
    }


}
