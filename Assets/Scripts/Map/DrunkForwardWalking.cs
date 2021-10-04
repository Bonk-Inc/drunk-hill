using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrunkForwardWalking : MonoBehaviour
{
    [SerializeField]
    private float acceleration = 1;
    [SerializeField]
    private float decceleration = 1;

    [SerializeField]
    private float maxSpeed = 0;
    [SerializeField]
    private float currentSpeed = 0;

    private ForwardMover forwardMover;
    private bool isAcellerating = true;

    private void Awake() {
        forwardMover = GetComponent<ForwardMover>();
    }


    void Update()
    {
        AdjustSpeed();
        Move();
    }

    private void AdjustSpeed(){
        if(isAcellerating){
            Accelerate();
        } else{
            Decelerate();
        }
        
    }

    private void Accelerate(){
        if(currentSpeed < maxSpeed)
                currentSpeed = Mathf.Lerp(currentSpeed, maxSpeed, acceleration * Time.deltaTime);
    }

    private void Decelerate(){
        if(currentSpeed > 0)
                currentSpeed = Mathf.Lerp(currentSpeed, 0, decceleration * Time.deltaTime);
    }

    private void Move(){
        forwardMover.MoveForward(currentSpeed);
    }

    public void SwitchAdustment(bool accelerate){
        isAcellerating = accelerate;
    }
}
