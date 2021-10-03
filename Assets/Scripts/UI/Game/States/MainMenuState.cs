using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuState : PdaState
{

    [SerializeField]
    private GameObject mainMenuUI;

    public override void Enter()
    {
        mainMenuUI.SetActive(true);
    }

    public override void Resume()
    {
        mainMenuUI.SetActive(true);
    }

    public override void Leave() 
    {
        mainMenuUI.SetActive(false);
    }

    public override void Pause()
    {
        mainMenuUI.SetActive(false);
    }
}
