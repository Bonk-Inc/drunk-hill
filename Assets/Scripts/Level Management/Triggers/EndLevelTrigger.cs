using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevelTrigger : MonoBehaviour
{
    [SerializeField]
    private LevelManager levelManager;

    private void OnTriggerEnter2D(Collider2D other) {
        levelManager.ToNextLevel();
    }
}
