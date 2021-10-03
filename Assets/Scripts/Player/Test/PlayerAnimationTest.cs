using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerAnimationTest : MonoBehaviour
{

    private Animator animator;

    private void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("InvokePlayerFall", 10, 10);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void InvokePlayerFall()
    {
        animator.SetTrigger("OnFalling");
        
        StartCoroutine("WaitForTime");
        
        animator.SetTrigger("OnStandUp");
    }

    private IEnumerator WaitForTime()
    {
        yield return new WaitForSeconds(Random.Range(1, 3));
    }
}
