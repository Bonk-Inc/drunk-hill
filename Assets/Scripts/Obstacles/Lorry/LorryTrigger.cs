using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LorryTrigger : Obstacle
{

    public ObstacleSpawner lorry;

    private void Reset() {
        lorry = GameObject.Find("Lorry").GetComponentInChildren<ObstacleSpawner>();
    }

    private void Awake() {
        if(lorry == null)
            lorry = GameObject.Find("Lorry").GetComponentInChildren<ObstacleSpawner>();
    }

    protected override void OnPlayerHit(Collider2D other)
    {
        lorry.SpawnObstacle();
    }
}
