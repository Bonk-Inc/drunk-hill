using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SideMover))]
public class DrunkSideMovement : MonoBehaviour
{
    
    [SerializeField]
    private float maxDrunkMovement = 1;

    [SerializeField]
    private float movementEqualsApprox = 0.01f;

    [SerializeField]
    private float acceleration = 1;

    private float currentMovement = 0;
    private float targetMovement = 0;

    private SideMover sideMover;

    private void Awake() {
        sideMover = GetComponent<SideMover>();
    }

    private void Update() {
        HandleMove();
    }

    private void HandleMove(){
        if(ApproximatelyEqual(currentMovement, targetMovement)){
            CreateNewTarget();
        }
        LerpToTarget();
        MoveInCurrentDirection();
    }

    private bool ApproximatelyEqual(float a, float b){
        return Mathf.Abs(currentMovement - targetMovement) < movementEqualsApprox;
    }

    private void CreateNewTarget(){
        targetMovement = Random.Range(-maxDrunkMovement, maxDrunkMovement);
    }

    private void LerpToTarget(){
        currentMovement = Mathf.Lerp(currentMovement, targetMovement, acceleration * Time.deltaTime);
    }

    private void MoveInCurrentDirection(){
        sideMover.MoveToSide(currentMovement);
    }

    

}
