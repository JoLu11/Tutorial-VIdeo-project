using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : BaseState
{
    private MovementSM moveSM;

    public Grounded(string name, MovementSM stateMachine) : base(name, stateMachine)
    {
        this.moveSM = (MovementSM)this.stateMachine;
    }

    public override void StateLogic()
    {
        base.StateLogic();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.moveSM.ChangeState(this.moveSM.jumpState);
        }

        if (this.moveSM.rigidbody2D.IsTouchingLayers(this.moveSM.enemyLayer))
        {
            this.moveSM.ChangeState(this.moveSM.deathState);
        }

    }
    
}