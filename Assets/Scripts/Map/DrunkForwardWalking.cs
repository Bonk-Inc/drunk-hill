using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrunkForwardWalking : MonoBehaviour
{
    [SerializeField]
    private float acceleration = 1;

    [SerializeField]
    private float maxSpeed = 0;
    [SerializeField]
    private float currentSpeed = 0;

    private ForwardMover forwardMover;

    private void Awake() {
        forwardMover = GetComponent<ForwardMover>();
    }


    void Update()
    {
        AdjustSpeed();
        Move();
    }

    private void AdjustSpeed(){
        if(currentSpeed < maxSpeed)
            currentSpeed = Mathf.Lerp(currentSpeed, maxSpeed, acceleration * Time.deltaTime);
    }

    private void Move(){
        forwardMover.MoveForward(currentSpeed);
    }
}
