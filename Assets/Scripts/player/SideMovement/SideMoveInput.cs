using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SideMover))]
public class SideMoveInput : MonoBehaviour
{
    
    [SerializeField]
    private float sideMoveSpeed = 1;

    private SideMover sideMover;

    private void Awake() {
        sideMover = GetComponent<SideMover>();
    }

    private void Update() {
        var axis = Input.GetAxis("Horizontal");
        sideMover.MoveToSide(axis * sideMoveSpeed);
    }

}
