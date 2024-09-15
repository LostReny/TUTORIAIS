using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : State
{
    public override void Enter()
    {
        isComplete = false;
    }

    public override void Do()
    {
        
        anim.SetInteger("transition", 2);
        
        isComplete = true;
    }

    public override void Exit()
    {

    }
}
