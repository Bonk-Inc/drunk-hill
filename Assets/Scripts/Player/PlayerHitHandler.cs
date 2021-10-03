using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PlayerHitHandler : MonoBehaviour
{
    
    public bool IsDead {get; private set;}

    public event Action<bool> OnPlayerHitObstacle;

    public void Hit(){
        OnPlayerHitObstacle?.Invoke(IsDead);
    }

    public void Die(){
        IsDead = true;
        Hit();
    }

}
