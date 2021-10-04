using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageObstacle : Obstacle
{
    
    protected override void OnPlayerHit(Collider2D other)
    {
        other.GetComponent<PlayerHitHandler>().Hit();
    }
}
