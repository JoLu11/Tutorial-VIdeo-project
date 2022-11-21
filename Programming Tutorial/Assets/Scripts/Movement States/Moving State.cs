using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : Grounded
{
    private MovementSM moveSM;

    public Movement(MovementSM stateMachine) : base("Movement", stateMachine)
    {
        this.moveSM = (MovementSM)this.stateMachine;
    }

    private float LeftRight;
    public override void Enter()
    {
        base.Enter();
        this.LeftRight = 0;
        this.moveSM.spRend.color = Color.cyan;
    }

    public override void StateLogic()
    {
        base.StateLogic();
        LeftRight = Input.GetAxis("Horizontal");
        if (Math.Abs(LeftRight) < (0.0001))
        {
            this.stateMachine.ChangeState(this.moveSM.idleState);
        }
    }

    public override void Action()
    {
        base.Action();
        Vector2 velocity = this.moveSM.rigidbody2D.velocity;
        velocity.x = this.moveSM.speed * this.LeftRight;
        this.moveSM.rigidbody2D.velocity = velocity;
    }
}