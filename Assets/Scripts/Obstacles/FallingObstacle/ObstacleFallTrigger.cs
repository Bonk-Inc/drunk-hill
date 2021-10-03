using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleFallTrigger : MonoBehaviour
{

    private const string PLAYER_TAG = "Player";

    [SerializeField]
    private ObstacleFaller fallHandler;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag(PLAYER_TAG)){
            fallHandler.Fall();
        }
    }
}
