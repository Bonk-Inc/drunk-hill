using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class PlayerAnimationHandler : MonoBehaviour {

    private Health health;

    [SerializeField]
    private PushDownAutomaton uiStates;

    [SerializeField]
    private PdaState gameOverState;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private float standUpDelay = 0.3f;

    [SerializeField]
    private DrunkForwardWalking forwardWalker;

    [SerializeField]
    private PlayerHitHandler hitHandler;

    [SerializeField]
    private SideMover sideMover;

    private void Awake() {
        health = GetComponent<Health>();
    }

    public void CheckGameOver() {
        if(health.IsDead){
            uiStates?.PushState(gameOverState);
        } else {
            StartCoroutine(DelayStandup());
        }
    }

    public void ResumeWalking() {
        forwardWalker.SwitchAdustment(true);
        sideMover.PauseMovement = false;
        hitHandler.StartInvulnerabletimer();
    }

    private IEnumerator DelayStandup(){
        yield return new WaitForSeconds(standUpDelay);
        animator.SetTrigger("OnStandUp");
    }
}