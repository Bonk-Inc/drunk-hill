using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PlayerHitHandler : MonoBehaviour
{
    
    public bool IsDead {get; private set;}

    public event Action<bool> OnPlayerHitObstacle;

    private Health health;

    [SerializeField]
    private DrunkForwardWalking forwardWalker;

    [SerializeField]
    private float invulnerabilityTimer = 2;

    [SerializeField]
    private float blinkInivTime = 0.08f;
    [SerializeField]
    private float blinkVisTime = 0.3f;

    [SerializeField]
    private SpriteRenderer sprite;

    public bool Invulnerable {get; set;}

    private void Awake() {
        health = GetComponent<Health>();
    }

    public void Hit(){

        if(Invulnerable)
            return;

        health.Damage(1);
        PlayerHit();
    }

    public void Die(){

        if(Invulnerable)
            return;

        IsDead = true;
        health.Kill();
        PlayerHit();
    }

    private void PlayerHit(){
        Invulnerable = true;
        forwardWalker.SwitchAdustment(false);
        OnPlayerHitObstacle?.Invoke(IsDead);
    }

    public void StartInvulnerabletimer(){
        StartCoroutine(InvulnerebleTimer());
    }

    private IEnumerator InvulnerebleTimer(){
        Invulnerable = true;
        Coroutine blinkRoutine = StartCoroutine(Blinker());
        yield return new WaitForSeconds(invulnerabilityTimer);
        StopCoroutine(blinkRoutine);
        Invulnerable = false;
        sprite.enabled = true;
    }

    private IEnumerator Blinker(){
        while (Invulnerable)
        {
            sprite.enabled = false; 
            yield return new WaitForSeconds(blinkInivTime);
            sprite.enabled = true; 
            yield return new WaitForSeconds(blinkVisTime);
        }
    }





}
