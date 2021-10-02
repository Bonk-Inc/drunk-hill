using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardMover : MonoBehaviour
{
    [SerializeField]
    private Mover mover;

    [SerializeField]
    private float distance;

    public void MoveForward(float amount){
        Vector2 direction = transform.up;
        Vector2 movement = direction.normalized * amount * Time.deltaTime;
        mover.Move(movement);
    }
}
