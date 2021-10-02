using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformMover : Mover
{
    private Transform objTransform;

    private void Awake() {
        objTransform = transform;
    }

    public override void Move(Vector3 move)
    {
        objTransform.position += move;
    }
}
