using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountdownTimerTest : MonoBehaviour
{
    [SerializeField]
    private PdaState countdownState;
    
    // Start is called before the first frame update
    void Start()
    {
        countdownState.Enter();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
