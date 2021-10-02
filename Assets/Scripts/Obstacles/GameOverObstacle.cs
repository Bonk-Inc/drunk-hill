using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverObstacle : MonoBehaviour
{

    [SerializeField]
    private PushDownAutomaton uiStates;

    [SerializeField]
    private PdaState gameOverState;

    private void OnTriggerEnter2D(Collider2D other) {
        uiStates.PushState(gameOverState);
    }
}
