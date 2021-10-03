using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditState : PdaState
{

    [SerializeField]
    private GameObject creditUI;

    public override void Enter()
    {
        creditUI.SetActive(true);
    }

    public override void Resume()
    {
        creditUI.SetActive(true);
    }

    public override void Leave() 
    {
        creditUI.SetActive(false);
    }
}
