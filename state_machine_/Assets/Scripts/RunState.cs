using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : State
{
    [Header("Movement")]
    public float speed;

    public override void Enter()
    {
        isComplete = false;
    }

    public override void Do()
    {   
        anim.SetInteger("transition", 1);
        isComplete = true;
    }

    public override void FixedDo()
    {
        OnMove();
        isComplete = true;
    }

    public override void Exit()
    {
    }

    private void OnMove()
    {
        player.rig.velocity = new Vector2(player.direction.x * speed, player.rig.velocity.y);
    }
}
