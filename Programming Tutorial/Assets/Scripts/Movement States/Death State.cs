using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : BaseState
{
    private MovementSM moveSM;

    public Death(MovementSM stateMachine) : base("Death", stateMachine)
    {
        this.moveSM = (MovementSM)this.stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
        this.moveSM.spRend.color = Color.red;
    }
}
