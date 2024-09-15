using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{

    public override void Enter()
    {
        isComplete = false;
    }

    public override void Do()
    {
        anim.SetInteger("transition", 0);
        isComplete = true;
    }

    public override void Exit() 
    {
    
    }
}
