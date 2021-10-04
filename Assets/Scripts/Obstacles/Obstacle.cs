using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Obstacle : MonoBehaviour
{
    const string PLAYER_TAG = "Player";

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag(PLAYER_TAG)){
            OnPlayerHit(other);
        }
    }

    protected abstract void OnPlayerHit(Collider2D other);
}
