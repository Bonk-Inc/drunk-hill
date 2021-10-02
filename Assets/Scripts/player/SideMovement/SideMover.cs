using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideMover : MonoBehaviour
{

    [SerializeField]
    private Mover mover;

    public void MoveToSide(float amount){
        Vector2 sideDir = transform.right;
        Vector2 sideMovement = sideDir.normalized * amount * Time.deltaTime;
        mover.Move(sideMovement);
    }

}
