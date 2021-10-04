using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelect : PdaState
{

    [SerializeField]
    private GameObject levelSelectUI;

    public override void Enter()
    {
        levelSelectUI.SetActive(true);
    }

    public override void Leave()
    {
        levelSelectUI.SetActive(false);
    }

    public void Return(){
        Machine.PopState();
    }
}
