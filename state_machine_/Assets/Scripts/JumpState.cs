using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : State
{
    [Header("Jump")]
    public float jumpForce;
       
    private int _extraJumps;
    public int extraJumps
    {
        get { return _extraJumps; }
        set { _extraJumps = value; }
    }

    public override void Enter()
    {
        isComplete = false;
        player.isJumping = true;
    }

    public override void Do()
    {
        anim.SetInteger("transition", 2);
        isComplete = true;
    }

    public override void FixedDo()
    {
        isComplete = true;
    }

    public override void Exit()
    {

    }

}
