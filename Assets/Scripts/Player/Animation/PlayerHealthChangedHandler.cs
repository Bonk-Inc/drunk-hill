using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerHitHandler))]
[RequireComponent(typeof(Animator))]
public class PlayerHealthChangedHandler : MonoBehaviour
{
    	
    private const string IS_FALLING_ANIM_TRIGGER = "OnFalling";
    private const string GAMEOVER_ANIM_BOOL = "isGameOver";
    
    private Animator animator;
    private Health health;

    [SerializeField]
    private SideMover mover;


    private void Awake() {
        animator = GetComponent<Animator>();
        health = GetComponent<Health>();
        health.OnHealthChange += OnPlayerHit;
    }

    private void OnPlayerHit(Health.HealthChangeArgs healthChangeArgs){
        mover.PauseMovement = true;
        animator.SetTrigger(IS_FALLING_ANIM_TRIGGER);
        if(healthChangeArgs.IsDead){
            animator.SetBool(GAMEOVER_ANIM_BOOL, true);
        }
    }

}
