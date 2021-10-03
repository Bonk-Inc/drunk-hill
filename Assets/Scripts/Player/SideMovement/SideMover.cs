using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideMover : MonoBehaviour
{
    public bool PauseMovement { get; set; } = false;

    [SerializeField]
    private Mover mover;

    public void MoveToSide(float amount){

        if(PauseMovement) return;

        Vector2 sideDir = transform.right;
        Vector2 sideMovement = sideDir.normalized * amount * Time.deltaTime;
        mover.Move(sideMovement);
    }

}
