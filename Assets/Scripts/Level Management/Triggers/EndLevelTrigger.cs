using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevelTrigger : MonoBehaviour
{
    [SerializeField]
    private LevelManager levelManager;

    [SerializeField]
    private AudioSource winSource;

    private void OnTriggerEnter2D(Collider2D other) {
        winSource?.Play();
        levelManager.ToNextLevel();
    }
}
