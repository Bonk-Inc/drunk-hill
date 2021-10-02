using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishGameUITrigger : MonoBehaviour
{
    [SerializeField]
    private PushDownAutomaton uiStates;

    [SerializeField]
    private PdaState gameFinishedState;

    [SerializeField]
    private LevelManager levelManager;

    private void Awake() {
        levelManager.OnLastLevelFinished += ToGameFinishedUI;
    }

    private void ToGameFinishedUI() {
        uiStates.PushState(gameFinishedState);
    }
}
