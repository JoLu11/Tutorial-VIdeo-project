using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollAttack : BaseState
{
    public BossSM sm;
    public bool fin;
    public int dir;

    public RollAttack(BossSM stm) : base("Rolling", stm)
    {
        sm = (BossSM)this.stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
        sm.spr.color = Color.magenta;
        
        // Determines direction to roll
        if (sm.player.transform.position.x - sm.rigidBody.position.x > 0)
        {
            dir = 1;
        }
        else
        {
            dir = -1;
        }
    }

    public override void StateLogic()
    {
        base.StateLogic();
        if (sm.rigidBody.velocity.y > 2)
        {
            sm.ChangeState(sm.idle);
        }
    }
    
    
    public override void Action()
    {
        base.Action();
        Vector2 v = sm.rigidBody.velocity;
        v.x = dir * sm.rollSpeed;
        sm.rigidBody.velocity = v;
    }


    public override void Exit()
    {
        base.Exit();
        sm.rigidBody.velocity = new Vector2(0, 2);
    }
}
