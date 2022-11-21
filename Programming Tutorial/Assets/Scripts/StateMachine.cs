using System.Collections;
using System.Collections.Generic;
using Unity.Services.Core;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public BaseState CurrentState;
    // Start is called before the first frame update

    // Returns true if there is a current state
    public bool NotEmptyState()
    {
        return this.CurrentState != null;
    }
    
    // Enters the starting state
    void Start()
    {
        this.CurrentState = this.GetFirstState();
        if (this.NotEmptyState())
        {
            this.CurrentState.Enter();
        }
    }

    // Update State Logic
    void Update()
    {
        if (this.NotEmptyState())
        {
            this.CurrentState.StateLogic();
            
        }
    }

    // Perform State Action
    void LateUpdate()
    {
        if (this.NotEmptyState())
        {
            this.CurrentState.Action();
        }
    }

    // Exit current state before entering a given state
    public void ChangeState(BaseState bs)
    {
        this.CurrentState.Exit();

        this.CurrentState = bs;
        this.CurrentState.Enter();
    }

    protected virtual BaseState GetFirstState()
    {
        return null;
    }
    
    
}
