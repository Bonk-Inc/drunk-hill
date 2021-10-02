using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushDownAutomaton : MonoBehaviour
{

    private Stack<IPdaState> states = new Stack<IPdaState>();

    public IPdaState CurrentState => states.Count > 0 ? states.Peek() : null;

    public void PushState(IPdaState state){

        if(state == null) return;

        state.Machine = this;
        CurrentState?.Pause();
        states.Push(state);
        state.Enter();
    }

    public void PopState(){
        if(states.Count == 0){
            return;
        }

        IPdaState oldState = states.Pop();
        oldState.Leave();
        CurrentState?.Reason();
    }

    private void Update() {
        IPdaState current = CurrentState;
        if(current != null){
            CurrentState.Reason();
            CurrentState.Update();
        }
    }


}
