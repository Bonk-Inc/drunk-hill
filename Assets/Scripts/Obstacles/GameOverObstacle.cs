using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverObstacle : MonoBehaviour
{

    const string PLAYER_TAG = "Player";



    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag(PLAYER_TAG)){
            other.GetComponent<PlayerHitHandler>().Die();
        }
    }
}
