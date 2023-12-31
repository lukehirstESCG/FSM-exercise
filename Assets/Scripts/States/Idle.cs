﻿using UnityEngine;

public class Idle : Grounded
{
    private float _horizontalInput;

    public Idle (MovementSM stateMachine) : base("Idle", stateMachine) {}

    public override void Enter()
    {
        base.Enter();
        sm.spriteRenderer.color = Color.black;
        _horizontalInput = 0f;
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        _horizontalInput = Input.GetAxis("Horizontal");
        if (Mathf.Abs(_horizontalInput) > Mathf.Epsilon)
            stateMachine.ChangeState(sm.movingState);
            sm.anim.SetBool("move", true);

        if (Input.GetKeyDown(KeyCode.V) == true)
            stateMachine.ChangeState(sm.attackState);
            sm.timer = 1;

        if (Input.GetKeyDown(KeyCode.M) == true)
            stateMachine.ChangeState(sm.deadState);
            Debug.Log("DEAD!");
            sm.anim.SetBool("dead", true);
    }

}
