using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : State
{
    public override void Enter()
    {
        isComplete = false;
    }

    public override void Do()
    {
        
        anim.SetInteger("transition", 1);
        
        isComplete = true;
    }

    public override void Exit()
    {

    }
}
