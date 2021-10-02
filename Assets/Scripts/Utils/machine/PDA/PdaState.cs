using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PdaState : MonoBehaviour, IPdaState
{
    public PushDownAutomaton Machine { get; set; }

    public abstract void Enter();
    public abstract void Leave();
    public virtual void Pause() {}
    public virtual void Reason() {}
    public virtual void Resume() {}
    public virtual void Update() {}

}
