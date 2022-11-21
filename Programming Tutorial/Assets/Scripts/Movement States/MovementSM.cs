using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovementSM : StateMachine
{
    [HideInInspector] public Idle idleState;
    [HideInInspector] public Movement movementState;
    [HideInInspector] public Jumping jumpState;
    [HideInInspector] public Death deathState;

    [SerializeField]
    public Rigidbody2D rigidbody2D;
    [SerializeField] 
    public float speed = 7.0f;

    [SerializeField] public float jumpHeight = 15.0f;

    [SerializeField]
    public SpriteRenderer spRend;

    public int enemyLayer = 3;
    
    private void Awake()
    {
        this.idleState = new Idle(this);
        this.movementState = new Movement(this);
        this.jumpState = new Jumping(this);
        this.deathState = new Death(this);
        
        enemyLayer = 1 << enemyLayer;
    }

    protected override BaseState GetFirstState()
    {
        return this.idleState;
    }
}
