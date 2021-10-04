using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsState : PdaState
{

    [SerializeField]
    private GameObject SettingUI;

    public override void Enter()
    {
        SettingUI.SetActive(true);
    }

    public override void Leave()
    {
        SettingUI.SetActive(false);
    }

    public void LeaveSettings(){
        Machine.PopState();
    }
}
