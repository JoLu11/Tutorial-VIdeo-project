using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jumping : BaseState
{
    private MovementSM moveSM;
    private bool onGround;
    private int groundLayer = 6;
    private float LeftRight;
    private float initialVelocity;
    
    public Jumping(MovementSM stateMachine) : base("Jumping", stateMachine)
    {
        this.moveSM = (MovementSM)this.stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
        this.moveSM.spRend.color = Color.blue;
        this.initialVelocity = (float) Math.Sqrt(this.moveSM.jumpHeight * 2.0f * this.moveSM.rigidbody2D.gravityScale);

        Vector2 vel = this.moveSM.rigidbody2D.velocity;
        vel.y += this.initialVelocity;
        this.moveSM.rigidbody2D.velocity = vel;

        this.LeftRight = 0;
    }

    public override void StateLogic()
    {
        base.StateLogic();
        if (onGround)
        {
            this.moveSM.ChangeState(this.moveSM.idleState);
        }
        
        if (this.moveSM.rigidbody2D.IsTouchingLayers(this.moveSM.enemyLayer))
        {
            this.moveSM.ChangeState(this.moveSM.deathState);
        }

    }

    public override void Action()
    {
        base.Action();
        
        // Is touching ground
        onGround = this.moveSM.rigidbody2D.velocity.y < 0.00001f &&
                   this.moveSM.rigidbody2D.IsTouchingLayers(1 << this.groundLayer);

        // Varying Jump Heights
        if (this.moveSM.rigidbody2D.velocity.y > 0.00001f)
        {
            if (!Input.GetKey(KeyCode.Space))
            {
                Vector2 pushDown = this.moveSM.rigidbody2D.velocity;
                pushDown.y -= this.initialVelocity / 5.0f;
                this.moveSM.rigidbody2D.velocity = pushDown;
            }
        }
        
        // Horizontal Movement
        LeftRight = Input.GetAxis("Horizontal");
        Vector2 velocity = this.moveSM.rigidbody2D.velocity;
        velocity.x = this.moveSM.speed * this.LeftRight;
        this.moveSM.rigidbody2D.velocity = velocity;

    }
}
