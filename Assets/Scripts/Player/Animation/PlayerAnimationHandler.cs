using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerHitHandler))]
public class PlayerAnimationHandler : MonoBehaviour {

    private PlayerHitHandler health;

    [SerializeField]
    private PushDownAutomaton uiStates;

    [SerializeField]
    private PdaState gameOverState;



    private void Awake() {
        health = GetComponent<PlayerHitHandler>();
    }

    public void CheckGameOver() {
        if(health.IsDead){
            uiStates?.PushState(gameOverState);
        }
    }
}