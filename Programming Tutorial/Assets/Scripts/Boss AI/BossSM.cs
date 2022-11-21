using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossSM : StateMachine
{

    [HideInInspector] public IdleDecide idle;
    [HideInInspector] public JumpAttack jump;
    [HideInInspector] public RollAttack roll;

    [SerializeField]
    public GameObject player;
    [SerializeField]
    public Rigidbody2D rigidBody;
    [SerializeField]
    public SpriteRenderer spr; 

    [SerializeField] public int jumpAttackHeight;
    [SerializeField] public int rollSpeed;
    [SerializeField] public int decideDis;

    private void Awake()
    {
        this.idle = new IdleDecide(this);
        this.jump = new JumpAttack(this);
        this.roll = new RollAttack(this);
        
    }

    protected override BaseState GetFirstState()
    {
        return this.idle;
    }
    

}
