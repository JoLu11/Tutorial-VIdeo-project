using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : Grounded
{
    private MovementSM moveSM;
    
    public Idle(MovementSM stateMachine) : base("Idle", stateMachine)
    {
        this.moveSM = (MovementSM)this.stateMachine;
    }

    private float LeftRight;
    public override void Enter()
    {
        base.Enter();
        this.LeftRight = 0;
        this.moveSM.spRend.color = Color.black;
    }

    public override void StateLogic()
    {
        base.StateLogic();
        LeftRight = Input.GetAxis("Horizontal");
        if (Math.Abs(LeftRight) > (0.0001))
        {
            this.stateMachine.ChangeState(this.moveSM.movementState);
        }
    }
}
